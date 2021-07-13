using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWallController : MonoBehaviour, IHitable
{
    [SerializeField] GameObject doorPrefab ;
    LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.Get();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHit()
    {
        if(!levelManager.GetDoorExists())
        {
            if (Random.Range(1, 100) < levelManager.GetChanceOfDoorSpawn() || levelManager.GetBrickWallLeft() == 0)
            {
                GameObject obj = Instantiate(doorPrefab);
                obj.transform.position = transform.position;
                levelManager.setDoorExists();
            }
        }
        
        Destroy(gameObject);
    }
}
