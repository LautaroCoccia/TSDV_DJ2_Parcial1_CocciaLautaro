using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] float timeToExplote = 2;
    [SerializeField] float range = 1;
    GameObject bomb;

    private void Start()
    {
        bomb = this.gameObject;
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeToExplote);
        
        ExplotionHit();
        Destroy(bomb);
    }
    void ExplotionHit()
    {
        RaycastHit hit;
        GameObject obj;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, range)) 
        {
            obj = hit.transform.gameObject;
            OnHit(obj);
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, range))
        {
            obj = hit.transform.gameObject;
            OnHit(obj);
        }
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            obj = hit.transform.gameObject;
            OnHit(obj);
        }
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, range))
        {
            obj = hit.transform.gameObject;
            OnHit(obj);
        }
    }

    void OnHit(GameObject hit)
    {
        if (hit.transform.tag == "Player")
        {
            transform.position = new Vector3(1, 0.5f, 1);
            //LevelManager.Get().UpdateHealth();
        }
        else if (hit.transform.tag == "Enemy" || hit.transform.tag == "BrickWall")
        {
            if (hit.transform.tag == "Enemy")
            {
                //LevelManager.Get().UpdateEnemies();
                //LevelManager.Get().UpdateScore(150);
            }
            else
                //LevelManager.Get().UpdateScore(50);
                Destroy(hit.transform.gameObject);
        }
    }
}
