using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IHitable
{
    [SerializeField] int layerMask = 8;
    float x;
    float z;
    
    // Update is called once per frame
    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        x = (x * Time.deltaTime) * 5;
        z = (z * Time.deltaTime) * 5;
        CenterPlayer();
    }

    private void CenterPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f) && z > 0)
        {
            if (hit.transform.gameObject.layer == layerMask)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                transform.position = new Vector3(transform.position.x, transform.position.y, hit.transform.position.z - 1);

            }
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 0.5f) && z < 0)
        {
            if (hit.transform.gameObject.layer == layerMask)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit.distance, Color.yellow);
                transform.position = new Vector3(transform.position.x, transform.position.y, hit.transform.position.z + 1);

            }
        }
        else
        {
            transform.Translate(0, 0, z);
        }

        if (Physics.Raycast(transform.position, transform.right, out hit, 0.5f) && x > 0)
        {
            if (hit.transform.gameObject.layer == layerMask)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
                transform.position = new Vector3(hit.transform.position.x - 1, transform.position.y, transform.position.z);

            }
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 0.5f) && x < 0)
        {
            if (hit.transform.gameObject.layer == layerMask)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * hit.distance, Color.yellow);
                transform.position = new Vector3(hit.transform.position.x + 1, transform.position.y, transform.position.z);
            }
        }
        else
        {
            transform.Translate(x, 0, 0);
        }
    }
    public void OnHit()
    {

    }
}
