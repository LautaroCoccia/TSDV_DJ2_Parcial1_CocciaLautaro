using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBallController : MonoBehaviour, IHitable
{
    [SerializeField] private float movementSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f))
        {
            if (hit.transform.gameObject.layer == 11)
            {
                hit.transform.gameObject.GetComponent<IHitable>().OnHit();
                OnHit();
            }
            else if (hit.transform.gameObject.layer == 12)
            {
                //Sigue derecho
            }
            else
            {
                OnHit();
            }
        }
    }
    public void OnHit()
    {
        Destroy(gameObject);

    }
}
