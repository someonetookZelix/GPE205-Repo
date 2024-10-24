using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    //Set Variables
    public Rigidbody rb;
    public float speed;
    public float rotSpeed;

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.UpArrow))
        {
            //Move forwards
            rb.velocity = transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Move backwards
            rb.velocity = -transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rotate to the right
            transform.Rotate(new Vector3(0, rotSpeed, 0) * Time.deltaTime * speed, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Rotate to the left
            transform.Rotate(new Vector3(0, -rotSpeed, 0) * Time.deltaTime * speed, Space.World);
        }
    }
}
