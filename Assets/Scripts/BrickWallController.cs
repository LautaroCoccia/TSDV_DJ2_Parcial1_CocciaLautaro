using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWallController : MonoBehaviour, IHitable
{
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
        Destroy(gameObject);
    }
}
