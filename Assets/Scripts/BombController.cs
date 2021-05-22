using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    [SerializeField] float TimeToExplote = 2;
    int bombsAlive = 0;
    GameObject bomb;
    Vector3 bombPos;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && bombsAlive==0)
        {
            bomb = Instantiate(bombPrefab);
            bomb.SetActive(false);
            bomb.transform.position =new Vector3( Mathf.Round( transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
            bombPos = bomb.transform.position;
            bombsAlive++;
            
        }
        if(bombsAlive>0)
        {
            if (transform.position.x < bomb.transform.position.x - 1 || transform.position.x > bomb.transform.position.x + 1 || transform.position.z < bomb.transform.position.z - 1 || transform.position.z > bomb.transform.position.z + 1)
            {
                bomb.SetActive(true);
                StartCoroutine(Timer());
                

            }
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(TimeToExplote);
        
        bombsAlive = 0;
        ExplotionHit();
        Destroy(bomb);
    }
    void ExplotionHit()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(bombPos, transform.TransformDirection(Vector3.right), out hit, 1) ||
            Physics.Raycast(bombPos, transform.TransformDirection(Vector3.left), out hit, 1) ||
            Physics.Raycast(bombPos, transform.TransformDirection(Vector3.forward), out hit, 1) ||
            Physics.Raycast(bombPos, transform.TransformDirection(Vector3.back), out hit, 1))
        {
            if(hit.transform.tag == "Player")
            {
                transform.position = new Vector3(1, 0.5f, 1);
                LevelManager.Get().UpdateHealth();
            }
            else if(hit.transform.tag == "Enemy"|| hit.transform.tag == "BrickWall")
            {
                if(hit.transform.tag == "Enemy")
                {
                    LevelManager.Get().UpdateEnemies();
                    LevelManager.Get().UpdateScore(150);
                }
                else
                    LevelManager.Get().UpdateScore(50);
                Destroy(hit.transform.gameObject);
            }
            bombPos = Vector3.zero;
        }
        
    }
}
