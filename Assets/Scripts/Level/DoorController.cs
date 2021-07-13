using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorController : MonoBehaviour, IHitable
{
    //public static Action algo;
    Material material;
    LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.Get();
        material = gameObject.GetComponent<MeshRenderer>().material;
        material.color = new Color(material.color.r, material.color.g, material.color.b, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnHit()
    {
        if(levelManager.GetIsActiveDoor())
        {
            levelManager.GameOver();
        }
    }

}
