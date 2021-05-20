using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    [SerializeField] float TimeToExplote = 2;
    int bombsAlive = 0;
    GameObject bomb;

    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && bombsAlive==0)
        {
            bomb = Instantiate(bombPrefab);
            bomb.transform.position =new Vector3( Mathf.Round( transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
            StartCoroutine(Timer());
            bombsAlive++;
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(TimeToExplote);
        bombsAlive--;
        Destroy(bomb);
    }
}
