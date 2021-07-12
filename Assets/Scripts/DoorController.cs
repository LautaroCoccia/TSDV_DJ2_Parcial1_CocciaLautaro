using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour, IHitable
{
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
            Debug.Log("Ganaste");
        }
    }

}
