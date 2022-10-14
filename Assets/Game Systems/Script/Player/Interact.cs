using System;
using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Intro RPG/Player/Interact
[AddComponentMenu("Game Systems/Player/Interact")]
public class Interact : MonoBehaviour
{
    #region Variables

    [Header("Player and Camera connection")]
    //create two gameObject variables one called player and the other mainCam
    public GameObject player;

    public float hitDistance = 10;
    public LayerMask layerMask;
    public     
        
    #endregion

    #region Start

    void Start()
    {
        
    }
    //connect our player to the player variable via tag
    //connect our Camera to the mainCam variable via tag

    #endregion

    #region Update

    void Update()
    {
        
        
        //hit == what has been hit
        if (Input.GetButtonDown("Interact"))
        { 
            RaycastHit _hitInfo; // info sent back from raycast hit
            Ray _interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); 
            if (Physics.Raycast(_interact, out _hitInfo, hitDistance)) 
            {
                if (_hitInfo.collider.tag == "NPC")
                {
                    if (_hitInfo.collider.GetComponent<DialogueMaster>())
                    {
                        _hitInfo.collider.GetComponent<DialogueMaster>().showDialogBox = true;
                        GameManager.GameManagerInstance.currentState = GameState.MenuState;
                    }
                    Debug.Log("Hit NPC");
                }
                if (_hitInfo.collider.tag == "Item") 
                { 
                    Debug.Log("Hit Item");
                }
            }
        }
    }
    //if our interact key is pressed
    //create a ray
    //this ray is shooting out from the main cameras screen point center of screen
    //create hit info
    //if this physics raycast hits something within 10 units

    #region NPC tag

    //and that hits info is tagged NPC
    //Debug that we hit a NPC             

    #endregion

    #region Item

    //and that hits info is tagged Item
    //Debug that we hit an Item               

    #endregion

    #endregion
}






