using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    //Set Variables
    public Rigidbody rb;
    public float speed;
    public float rotSpeed;

    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode right = KeyCode.D;
    public KeyCode left = KeyCode.A;

    // Update is called once per frame
    void Update()
    {
        //Move forwards and backwards
            Vector3 movement = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
            if (Input.GetKey(forward) || Input.GetKey(backward))
            {
                transform.position += transform.rotation * movement * speed * Time.deltaTime;
            }

        if (Input.GetKey(right))
        {
            //Rotate to the right
            transform.Rotate(new Vector3(0, rotSpeed, 0) * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(left))
        {
            //Rotate to the left
            transform.Rotate(new Vector3(0, -rotSpeed, 0) * Time.deltaTime * speed, Space.World);
        }
    }
}
