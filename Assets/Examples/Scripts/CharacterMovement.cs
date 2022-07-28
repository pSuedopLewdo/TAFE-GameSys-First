using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CharacterMovement : MonoBehaviour
{
    public CharacterController charC;
    public float speed = -20;
    
    // Start is called before the first frame update
    void Start()
    {
        charC = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        charC.Move(Vector3.forward * speed * Time.deltaTime);
    }
}
