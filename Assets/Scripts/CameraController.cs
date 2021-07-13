using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] Vector3 offsetPos;
    [SerializeField] Vector3 offsetRotation;
    [SerializeField] bool setLookAt = false;
    private void Start()
    {
        offsetPos = transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.position =new Vector3(player.position.x, player.position.y + offsetPos.y, offsetPos.z);
        transform.rotation = Quaternion.Euler(offsetRotation);
        if(setLookAt)
            transform.LookAt(player);
    }
}
