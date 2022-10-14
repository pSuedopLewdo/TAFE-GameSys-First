using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneChoice : DialogueMaster
{
    [Header("Choice Marker")] 
    public int choiceIndex;

    private void OnGUI()
    {
        if (showDialogBox)
        {
            {
                //the dialogue box takes up the whole bottom 3rd of the screen and displays the NPCs name and current dialogue line
                GUI.Box(new Rect(0, 6 * UIManager.scr.y, Screen.width, 3 * UIManager.scr.y),
                    $"{charName}: {dialogue[index]}");
                //if not at the end of the dialogue or not at the options part
                if (index < dialogue.Length - 1 && index != choiceIndex) // -1 cause want the last one ot be a goodbye button and end dialogue
                {
                    if (GUI.Button(
                            new Rect(13.25f * UIManager.scr.x, 8 * UIManager.scr.y, 2.5f * UIManager.scr.x,
                                .75f * UIManager.scr.y), "Next"))
                    {
                        index++;
                    }
                }
                else if (index == choiceIndex)
                {
                    //YES button lets you continue the conversation
                    if (GUI.Button(
                            new Rect(11f * UIManager.scr.x, 8 * UIManager.scr.y, 2.5f * UIManager.scr.x, .75f * UIManager.scr.y), "Yes"))
                    {
                        index++;
                    }
                    //NO button abruptly ends the dialogue with the player
                    if (GUI.Button(
                             new Rect(13.25f * UIManager.scr.x, 8 * UIManager.scr.y, 2.5f * UIManager.scr.x, .75f * UIManager.scr.y), "No"))
                    {
                        index = dialogue.Length -1 ;
                    }
                }
                else
                {
                    if (GUI.Button(
                            new Rect(13 * UIManager.scr.x, 8 * UIManager.scr.y, 2.5f * UIManager.scr.x, .75f * UIManager.scr.y), ""))
                    {
                        EndDialogue();
                    }
                }
            }
        }
    }
}
