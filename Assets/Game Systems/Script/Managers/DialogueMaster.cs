using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMaster : MonoBehaviour
{
    
    #region Variables

    [Header("References")]
    //boolean to toggle if we can see a characters dialogue box
    public bool showDialogBox;

    //index for our current line of dialogue and an index for a set question marker of the dialogue 
    public int index;
    //object reference to the player
    public GameObject player;
    //mouse look script reference for the main camera
    
    [Header("NPC Name and Dialogue")]
    //name of this specific NPC
    public string charName;
    
    //array for text for our dialogue
    public string[] dialogue;

    #endregion
    
    
    // Start is called before the first frame update
    public void EndDialogue()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        showDialogBox = false;
        index = 0;
    }
}
