using System;
using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option PRG/Mouse Look
[AddComponentMenu("Game Systems/Player/Mouse Look")]
public class MouseLook : MonoBehaviour
{
    /*
     enums are what we call state value variables 
     they are comma separated lists of identifiers
     we can use them to create Types or Categories
    */
    #region RotationalAxis
    //Create a public enum called RotationalAxis
    public enum RotationalAxis
    {
        MouseX,
        MouseY,
    }
    #endregion

    #region Variables

    [Header("Rotation")]
    //create a public link to the rotational axis called axis and set a default axis
    public RotationalAxis axis;

    [Header("Sensitivity")] 
    [Space(8)]
    //public floats for our x and y sensitivity
    public float senseX = 5;
    public float senseY = 5;

    [Header("Y Rotation Clamp")]
    //max and min Y rotation
    public float maxY;
    public float minY;
    
    [Space(8)]
    //we will have to invert our mouse position later to calculate our mouse look correctly
    //float for rotation Y
    public float rotY;

    [Header("Mouse")] 
    public bool cursorVisible = false;
    public bool mouseInvert = false;

    [Header("RigidBody")] 
    public Rigidbody rb;
    #endregion

    #region Start

    void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            rb = this.GetComponent<Rigidbody>();
            GetComponent<Rigidbody>().freezeRotation = true;
        }
        //makes the cursor visible
        Cursor.visible = cursorVisible;
    
        //Locks the mouse cursor to the centre 
        Cursor.lockState = CursorLockMode.Locked;
    }
    //Lock Cursor to middle of screen
    //Hide Cursor from view
    //if our game object has a rigidbody attached to it
    //set the rigidbodys freezRotaion to true

    #endregion

    #region Update

    void Update()
    {
        if (axis == RotationalAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * senseX, 0);
        }
        else
        {
            rotY += Input.GetAxis("Mouse Y") * senseY;
            rotY = Mathf.Clamp(rotY, minY, maxY);
            if(!mouseInvert)
            {
                transform.localEulerAngles = new Vector3(-rotY, 0, 0);
            }
            else
            {
                transform.localEulerAngles = new Vector3(rotY, 0, 0);
            }
        }
    }

    #region Mouse X

    //else if we are rotating on the X
    //transform the rotation on our game objects Y by our Mouse input Mouse X times X sensitivity
    //x                y                          z

    #endregion

    #region Mouse Y

    //else we are only rotation on the Y
    //our rotation Y is pulse equals  our mouse input for Mouse Y times Y sensitivity
    //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
    //transform our local position to the nex vector3 rotaion - y rotaion on the x axis and local euler angle Y on the y axis

    #endregion

    #endregion
}













