using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelCreator : MonoBehaviour
{
	[Header("Level Data")]
	[SerializeField]
	private int levelWidth = 10;
	[SerializeField]
	private int levelHeight = 10;
	[SerializeField]
	private int destructibleWallAmount = 5;
	[SerializeField]
	private float floorDistance = 0.5f;

	[Header("Prefabs")]
	[SerializeField]
	private GameObject floorPrefab;
	[SerializeField]
	private GameObject exteriorWallVerticalPrefab;
	[SerializeField]
	private GameObject exteriorWallHorizontalPrefab;
	[SerializeField]
	private GameObject wallPrefab;
	[SerializeField]
	private GameObject destructibleWallPrefab;

	List<int> emptyPositions = new List<int>();

	void Start()
	{
		BuildLevel();
	}

	void BuildLevel() {
		//handle input values
		levelWidth = Mathf.Clamp(levelWidth, 3, int.MaxValue);
		levelHeight = Mathf.Clamp(levelHeight, 3, int.MaxValue);
		if (levelHeight % 2 == 0) levelHeight++;
		if (levelWidth % 2 == 0) levelWidth++;
		int innerWallsAmount = ((levelWidth - 1) * (levelHeight - 1)) / 4;
		int availableSpacesInGrid = levelWidth * levelHeight;
		destructibleWallAmount = Mathf.Clamp(destructibleWallAmount, 1, availableSpacesInGrid - innerWallsAmount);
		lastHeight = levelHeight;
		lastWidth = levelWidth;
		//Clear possible garbage
		foreach (Transform child in transform) { Destroy(child.gameObject); }
		//build outer walls
		for (int x = -1; x < levelWidth + 1; x++)
		{
			Instantiate(exteriorWallHorizontalPrefab, new Vector3(x, floorDistance, -1), Quaternion.identity, transform);
			Instantiate(exteriorWallHorizontalPrefab, new Vector3(x, floorDistance, levelHeight), Quaternion.identity, transform);
		}
		for (int y = 0; y < levelHeight; y++)
		{
			Instantiate(exteriorWallVerticalPrefab, new Vector3(-1, floorDistance, y), Quaternion.identity, transform);
			Instantiate(exteriorWallVerticalPrefab, new Vector3(levelWidth, floorDistance, y), Quaternion.identity, transform);
		}
		//build floor & inner walls
		emptyPositions = new List<int>();
		for (int x = 0; x < levelWidth; x ++)
		{
			for (int y = 0; y < levelHeight; y ++)
			{
				Instantiate(floorPrefab, new Vector3(x, 0, y), Quaternion.identity, transform);
				if (x % 2 == 1 && y % 2 == 1)
					Instantiate(wallPrefab, new Vector3(x, floorDistance, y), Quaternion.identity, transform);
				else
					emptyPositions.Add(y* levelWidth + x); //CRANEAR ESTO
			}
		}
		//build destructible walls
		for (int i = 0; i < destructibleWallAmount; i++)
		{
			int rnd = Random.Range(0, emptyPositions.Count);
			int arrayPos = emptyPositions[rnd];
			int x = arrayPos % levelWidth;
			int y = arrayPos / levelWidth;
			Instantiate(destructibleWallPrefab, new Vector3(x, floorDistance, y), Quaternion.identity, transform);
			emptyPositions.RemoveAt(rnd);
		}
	}

	private int lastWidth;
	private int lastHeight;

	void Update()
	{
		if (lastHeight != levelHeight || lastWidth != levelWidth)
	    {
			BuildLevel();
	    }
    }
}

//public class UI
//{
//    void Start()
//    {
//        Player.OnPlyaerDataChanged += refreshUI;
//    }
//}
//
//public class Player
//{
//    public static event Action<Player> OnPlyaerDataChanged;
//    OnPlyaerDataChanged(this)
//}
