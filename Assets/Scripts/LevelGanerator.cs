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
    int Position;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            if(pool.tag == "Wall")
            {
                Position = pool.size;
                WallInitializer(pool.size, pool.prefab);
            }
            else if (pool.tag == "Floor")
            {
                FloorInitializer(Position, pool.prefab);
            }
            else if(pool.tag == "BrickWall")
            {
                BrickWallInitializer(Position, pool.prefab);
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
                        obj.transform.SetParent(gameObject.transform);
                        obj.transform.position = new Vector3(i, 0.5f, j);
                    }
                }
            }
        }
    }
    void FloorInitializer(int size, GameObject prefab)
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.SetParent(gameObject.transform);
        obj.transform.localScale = new Vector3( (size / 4) + 0.5f, 1, (size / 4) + 0.5f);
        obj.transform.position = new Vector3(size + 1, 0, size + 1);
    }
    void BrickWallInitializer(int size, GameObject prefab)
    {
        float x = 0;
        float z = 0;

        for (int i = 0; i < (size * 2) + 1; i++)
        {
            do
            {
                x = Random.Range(1, (size *2 ) + 1);
                z = Random.Range(1, (size *2) + 1);
            } while (x % 2 == 0 && z %2==0);
            GameObject obj = Instantiate(prefab);
            obj.transform.SetParent(gameObject.transform);
            obj.transform.position = new Vector3(x, 0.5f, z);
            
        }
    }
}
