using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardsMovement : MonoBehaviour
{
    public float speed = 5;

    public Vector3 target;
    // Update is called once per frame
    void Start()
    {
        target = transform.position + new Vector3(0, 25, 600);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target,speed);
    }
}
