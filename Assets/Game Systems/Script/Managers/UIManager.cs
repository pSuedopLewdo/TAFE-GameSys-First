using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Vector2 scr; //Screens x and y

    private static UIManager _uiManagerInstance; // instance if it

    public static UIManager UIManagerInstance
    {
        //read, => this means it is getting the other side of it
        //get { return _uiManagerInstance; } this is the same as => it is returning the value of _uiManagerInstance
        get => _uiManagerInstance;

        //write 
        private set
        {
            if (_uiManagerInstance == null) // if there is not reference set the reference to this instance
            {
                _uiManagerInstance = value; //value is whatever is being set through which in this case is UIManagerInstance
            }
            else if (_uiManagerInstance != value) //if what is being passed through is not the value. it is imposter kill it
            {
                //it is imposter kill it
                Debug.Log($"{nameof(UIManager)}Instance already exists destroy duplicate! There can only be one");
                Destroy(value); // $ is a type of formatting within the debug logs
            }
        }
    }

    private void Awake()
    {
        UIManagerInstance = this; // whichever instance gets grabbed is set to this if there is another it is destroyed. Kill the imposter
    }


    void Start()
    {
        //Sets the aspect ratio form the start of the gameObject
        UpdateUIScale();
    }

    // Update is called once per frame
    void Update()
    {
        //calls the function so maintain the aspect ratio
        UpdateUIScale();
    }

    public static void UpdateUIScale()
    {
        //if the aspect ratio isn't equal scr it sets it to 16/9
        if (new Vector2(Screen.width/16, Screen.height/9) != scr)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        }
    }
}
