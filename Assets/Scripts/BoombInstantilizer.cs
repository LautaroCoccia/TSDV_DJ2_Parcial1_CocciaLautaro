using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoombInstantilizer : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    [SerializeField] int maxCant = 1;
    int bombsAlive = 0;
    GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && bombsAlive < maxCant)
        {
            bomb = Instantiate(bombPrefab);
            bomb.transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
            bombsAlive++;
        }
        if (bombsAlive > 0)
        {
            if (transform.position.x < bomb.transform.position.x - 1 || transform.position.x > bomb.transform.position.x + 1 || transform.position.z < bomb.transform.position.z - 1 || transform.position.z > bomb.transform.position.z + 1)
            {
                bomb.SetActive(true);
            }
        }
    }
}
