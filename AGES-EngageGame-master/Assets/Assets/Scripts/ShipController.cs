using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public float speed = 1f;
    public float rotationSpeed = 30f;

    private new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();    
    }

    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);


        //float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;

                //transform.localPosition += transform.right * h;
                transform.localPosition += transform.forward * v;

        //Vector3 RIGHT = transform.TransformDirection(Vector3.right);
        Vector3 FORWARD = transform.TransformDirection(Vector3.forward);

        //transform.localPosition += RIGHT * h;
        transform.localPosition += FORWARD * v;
    }
}
