using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Adds a component menu
[AddComponentMenu("Game Systems/Player/Movement")]
//Requires and adds a Character Controller onto the game object 
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    #region Variables
    [Header("Character")]
    public CharacterController charC;
    
    [Space(8)]
    public Vector3 moveDir;
    
    [Space(8)]
    //world + speed variables
    [Header("Character Variables")] 
    public float speed = 5;
    public float jumpSpeed = 8;
    public float gravity = 20;

    //Movement speed variables
    [Space(8)]
    public float crouch = 2.5f;
    public float walk = 5;
    public float run = 10;
    public float superSpeed = 100;
    
    #endregion
    void Start()
    {
        //Gets the character controller on this gameObject
        if (CompareTag("Player"))
        {
            charC = this.GetComponent<CharacterController>();
        }
    }
    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (GameManager.GameManagerInstance.currentState == GameState.GameState)
        {
            if (charC.isGrounded)
            {
                moveDir = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
                moveDir = transform.TransformDirection(moveDir);
                moveDir *= speed;
                if (Input.GetButton("Jump"))
                {
                    moveDir.y = jumpSpeed;
                }
            }
            moveDir.y -= gravity * Time.deltaTime;
            charC.Move(moveDir * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = run;
            }
            else if (Input.GetKey(KeyCode.LeftCommand))
            {
                speed = crouch;
            }
            else if (Input.GetKey(KeyCode.K))
            {
                speed = superSpeed;
            }
            else
            {
                speed = walk;
            }
        }
    }
}
