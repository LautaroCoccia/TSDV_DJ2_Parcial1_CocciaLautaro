using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    Vector3 offset;
    private void Start()
    {
        offset = transform.position;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position =new Vector3(player.position.x, player.position.y + offset.y, offset.z);
        transform.LookAt(player);
    }
}
