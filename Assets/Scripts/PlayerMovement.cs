using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float velocity = 10f;
    
    [Space(8)]
    public Vector3 moveDirection = Vector3.zero;

    public Transform cameraPos;
    public Transform playerPos;
    public Transform cubePos;
    public Transform lightPos;
    
    void Start()
    {
        cameraPos = Camera.main.transform;
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lightPos = GameObject.Find("Directional Light").GetComponent<Transform>();
        cubePos = this.transform;
    }

    void Update()
    {
        
    }
}
