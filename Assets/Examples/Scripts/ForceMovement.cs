using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ForceMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float force = -5;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * force * Time.deltaTime);
    }
}
