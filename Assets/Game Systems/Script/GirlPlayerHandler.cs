using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GirlPlayerHandler : MonoBehaviour
{
    public Animator anim;
    public CharacterController charC;
    public Vector3 moveDir;
    public float speed, jumpSpeed = 8, gravity = 20, crouch = 2.5f, walk = 5, run = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        charC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (charC.isGrounded)
        {
            Movement();
        }
    }

    void Movement()
    {
        anim.SetFloat("isCrouching", 1);
        moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (moveDir == Vector3.zero)
        {
            speed = 0;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = run;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                speed = crouch;
                anim.SetFloat("isCrouching", 0);
            }
            else
            {
                speed = walk;
            }
            anim.SetFloat("moveSpeed", speed);
            anim.SetFloat("horizontal", moveDir.x);
            anim.SetFloat("vertical", moveDir.z);
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
        }

        moveDir.y -= gravity * Time.deltaTime;
        charC.Move(moveDir * Time.deltaTime);
    }
    
}
