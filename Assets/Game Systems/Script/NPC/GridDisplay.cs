using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridDisplay : MonoBehaviour
{
    private void OnGUI() //lets us run IMGUI(immediate mode GUI) and events
    {
        //nested for loop
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                //Create a GUI box
                //Rect is made up of 4 values, these are x and y start positions, x and y size (NOT END POSITIONS)
                //then the final part is the display content
                GUI.Box(new Rect(x * UIManager.scr.x,y * UIManager.scr.y,UIManager.scr.x,UIManager.scr.y), "");
                //16*1/16, 9*1/9 basically 1x1
                GUI.Label(new Rect(x * UIManager.scr.x,y * UIManager.scr.y,UIManager.scr.x,UIManager.scr.y), "");
            }
        }
    }
}
