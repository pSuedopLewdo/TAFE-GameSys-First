using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VelocityMovement : MonoBehaviour
{
    public float vel = 5;
    public Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        rb.velocity = Vector3.forward * vel * Time.deltaTime;
    }
}
