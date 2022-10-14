using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//this script can be found in the Component section under the option NPC/Dialogue
[AddComponentMenu("NPC/Dialogue")]
public class Dialogue : DialogueMaster
{
    #region OnGUI

    private void OnGUI()
    {
        //if our dialogue can be seen on screen
        if (showDialogBox)
        {
            //the dialogue box takes up the whole bottom 3rd of the screen and displays the NPCs name and current dialogue line
            GUI.Box(new Rect(0, 6 * UIManager.scr.y, Screen.width, 3 * UIManager.scr.y),
                $"{charName}: {dialogue[index]}");
            //if not at the end of the dialogue or not at the options part
            if (index < dialogue.Length - 1) // -1 cause want the last one ot be a goodbye button and end dialogue
            {
                if (GUI.Button(
                        new Rect(13.25f * UIManager.scr.x, 8 * UIManager.scr.y, 2.5f * UIManager.scr.x,
                            .75f * UIManager.scr.y), ""))
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    index++;
                }
            }
            else
            {
                if (GUI.Button(
                        new Rect(13 * UIManager.scr.x, 8 * UIManager.scr.y, 2.5f * UIManager.scr.x,
                            .75f * UIManager.scr.y), ""))
                {
                    EndDialogue();
                }
            }
        }
    }
    #endregion
}
