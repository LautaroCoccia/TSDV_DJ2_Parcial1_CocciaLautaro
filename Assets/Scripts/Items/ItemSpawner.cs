using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSpawner : MonoBehaviour
{
    LevelManager lvlManager;
    private void Start()
    {
        lvlManager = LevelManager.Get();
    }
    public virtual void SpawnItem()
    {
        if(Random.Range(0,101)< lvlManager.GetChanceToSpawnItem())
        {
            GameObject obj = Instantiate(lvlManager.GetItemList()[Random.Range(0, lvlManager.GetItemList().Count)]);
            obj.transform.position = transform.position;
        }
    }
}
