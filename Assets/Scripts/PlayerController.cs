using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TitosQuest.Framework.BombermanProto
{
    public class PlayerController : MonoBehaviour, IHitable
    {
        [SerializeField] private float speed = 15;
        [SerializeField] private float displacementSpeed = 20;
        [SerializeField] private float rayDistance = 1;
        [SerializeField] private LevelManager levelManager;
        private Vector3 direction;
        // Update is called once per frame
        void Update()
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            if (ver != 0 && hor != 0)
                ver = 0;

            direction = new Vector3(hor, 0, ver);
            direction.Normalize();
            Move(direction);
        }

        void Move(Vector3 direction) //TODO Extraer esto a otra clase y que este player y un hipotético enemy hereden de esa clase.
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, rayDistance))
            {
                if(hit.transform.tag =="Door"|| hit.transform.tag == "Item")
                {
                    hit.transform.gameObject.GetComponent<IHitable>().OnHit();
                }
                Debug.DrawRay(transform.position, direction * rayDistance, Color.yellow);
            }
            else
            {
                transform.Translate(direction * Time.deltaTime * speed, Space.World);

                float x = Mathf.RoundToInt(transform.position.x);
                float z = Mathf.RoundToInt(transform.position.z);

                if (direction.x != 0)
                {
                    Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, z);
                    transform.position = Vector3.Lerp(transform.position, targetPosition,
                        displacementSpeed * Time.deltaTime);
                }

                if (direction.z != 0)
                {
                    Vector3 targetPosition = new Vector3(x, transform.position.y, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, targetPosition,
                        displacementSpeed * Time.deltaTime);
                }
            }
        }
        public void OnHit()
        {
            transform.position = new Vector3(1, 0.5f, 1);
            levelManager.UpdateHealth();
        }
    }
}