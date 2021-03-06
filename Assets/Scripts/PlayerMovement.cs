using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    [SerializeField]
    private float speed = 10f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            y = 1;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            y = -1;
        }
        Vector3 move = transform.right * x +transform.forward * z + transform.up*y;
        controller.Move(move * speed * Time.deltaTime);
    }
}
