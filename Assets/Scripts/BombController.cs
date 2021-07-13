using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BombController : MonoBehaviour
{
    [SerializeField] float timeToExplote = 2;
    [SerializeField] float range = 1;
    GameObject bomb;
    public static Action DestroyBomb;

    private void Start()
    {
        bomb = this.gameObject;
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeToExplote);
        
        ExplotionHit();
        DestroyBomb?.Invoke();
        Destroy(bomb);
    }
    void ExplotionHit()
    {
        RaycastHit hit;
        GameObject obj;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, range/2)) 
        {
            obj = hit.transform.gameObject;
            OnHit(obj);
        }
        else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, range / 2))
        {
            obj = hit.transform.gameObject;
            OnHit(obj);
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, range/2))
        {
            obj = hit.transform.gameObject;
            OnHit(obj);
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, range))
        {
            obj = hit.transform.gameObject;
            OnHit(obj);
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range/2))
        {
            obj = hit.transform.gameObject;
            OnHit(obj);
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
        {
            obj = hit.transform.gameObject;
            OnHit(obj);
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, range/2))
        {
            obj = hit.transform.gameObject;
            OnHit(obj);
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, range))
        {
            obj = hit.transform.gameObject;
            OnHit(obj);
        }
    }

    void OnHit(GameObject hit)
    {
        if (hit.transform.tag == "Hitable" || hit.transform.tag == "Player")
        {
            hit.transform.gameObject.GetComponent<IHitable>().OnHit();
        }
    }
}
