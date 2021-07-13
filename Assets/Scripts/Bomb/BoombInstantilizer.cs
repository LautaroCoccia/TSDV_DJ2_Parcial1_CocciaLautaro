using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoombInstantilizer : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    [SerializeField] int maxCant = 1;
    [SerializeField] int range = 1;
    int bombsAlive = 0; 
    public delegate void UpdateRange(ref int newRange);
    public static UpdateRange updateRange;
    
    GameObject bomb;
    LevelManager lvlManager;

    // Start is called before the first frame update
    void Start()
    {
        lvlManager =LevelManager.Get();
        lvlManager.SetBombRangeUI(range);
        lvlManager.SetBombCantUI(maxCant);
        MoreBombs.AddBombs += SetNewMaxBombs;
        MoreRange.AddBombRange += SetNewRange;
        BombController.DestroyBomb += destroyBomb;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && bombsAlive < maxCant)
        {
            bomb = Instantiate(bombPrefab);
            bomb.transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
            updateRange?.Invoke(ref range);
            bombsAlive++;
        }
    }
    void destroyBomb()
    {
        bombsAlive--;
    }
    private void OnDisable()
    {
        MoreRange.AddBombRange -= SetNewRange;
        MoreBombs.AddBombs -= SetNewMaxBombs;
        BombController.DestroyBomb -= destroyBomb;
    }
    private void SetNewRange()
    {
        range++;
        lvlManager.SetBombRangeUI(range);
    }
    void SetNewMaxBombs()
    {
        maxCant++;
        lvlManager.SetBombCantUI(maxCant);

    }
}
