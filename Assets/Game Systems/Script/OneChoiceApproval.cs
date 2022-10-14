using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneChoiceApproval : OneChoice
{
    [Header("How Much the PClikes you")] public int approval;

    [Header("The dialogue based on approval")]
    public string[] likeText;
    public string[] neutralText;
    public string[] dislikeText;

    private void Start()
    {
        approval = 0;
        ChangeDlg(approval);
    }

    void ChangeDlg(int approval)
    {
        switch (approval)
        {
            case -1:
                dialogue = dislikeText;
                break;
            case 0:
                dialogue = neutralText;
                break;
            case 1:
                dialogue = likeText;
                break;
        }
    }

    private void OnGUI()
    {
        if (showDialogBox)
        {
            //the dialogue box takes up the whole bottom 3rd of the screen and displays the NPCs name and current dialogue line
            GUI.Box(new Rect(0, 6 * UIManager.scr.y, Screen.width, 3 * UIManager.scr.y),
                $"{charName}: {dialogue[index]}");
            //if not at the end of the dialogue or not at the options part
            if (index < dialogue.Length - 1 &&
                index != choiceIndex) // -1 cause want the last one ot be a goodbye button and end dialogue
            {
                if (GUI.Button(
                        new Rect(13.25f * UIManager.scr.x, 8 * UIManager.scr.y, 2.5f * UIManager.scr.x, .75f * UIManager.scr.y), "Next"))
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
                    if (approval < 1)
                    {
                        approval++;
                    }
                    ChangeDlg(approval);
                }

                //NO button abruptly ends the dialogue with the player
                if (GUI.Button(
                        new Rect(13.25f * UIManager.scr.x, 8 * UIManager.scr.y, 2.5f * UIManager.scr.x, .75f * UIManager.scr.y), "No"))
                {
                    index = dialogue.Length - 1;
                    if (approval > 1)
                    {
                        approval--;
                    }
                    ChangeDlg(approval);
                }
            }
            else
            {
                if (GUI.Button(new Rect(13 * UIManager.scr.x, 8 * UIManager.scr.y, 2.5f * UIManager.scr.x, .75f * UIManager.scr.y), ""))
                {
                    EndDialogue();
                }
            }
        }
    }
}
