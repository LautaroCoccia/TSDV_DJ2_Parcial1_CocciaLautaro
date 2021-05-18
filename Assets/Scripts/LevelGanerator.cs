using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGanerator : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        int Position;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            if(pool.tag == "Wall")
            {
                Position = pool.size;
                WallInitializer(pool.size, pool.prefab);
            }
            
        }
    }
    void WallInitializer(int size, GameObject prefab)
    {
        for (int i = 0; i < (size * 2) + 1; i++)
        {
            if ((i % 2) == 0 && i > 0)
            {
                for (int j = 0; j < (size * 2) + 1; j++)
                {
                    if ((j % 2) == 0 && j > 0)
                    {
                        GameObject obj = Instantiate( prefab);
                        obj.transform.position = new Vector3(i, 0.5f, j);
                    }
                }
            }
        }
    }
}
