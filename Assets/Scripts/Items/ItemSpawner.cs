using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> itemList;
    [SerializeField] int chanceToSpawnItem = 50;

    private void OnDestroy()
    {
        if(Random.Range(0,101)<chanceToSpawnItem)
        {
            GameObject obj = Instantiate(itemList[Random.Range(0, itemList.Count)]);
            obj.transform.position = transform.position;
        }
    }
}
