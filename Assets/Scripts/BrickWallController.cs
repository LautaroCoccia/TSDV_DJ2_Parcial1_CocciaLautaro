using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWallController : MonoBehaviour, IHitable
{
    [SerializeField] GameObject doorPrefab ;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHit()
    {
        if(Random.Range(1, 100) < LevelManager.Get().GetChanceOfDoorSpawn())
        {
            GameObject obj = Instantiate(doorPrefab);
            obj.transform.position = transform.position;
        }
        Destroy(gameObject);
    }
}
