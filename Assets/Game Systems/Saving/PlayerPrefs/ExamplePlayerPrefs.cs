using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlayerPrefs : MonoBehaviour
{
    /*
        Pros
            * Pre-Build
                 *easy to use functions
                 *search with keywords
             *works similar to dictionary key words + value attached
          Cons
             *Only saves int, float, string CANT SAVE BOOLS
             *The save and load functions only call / save (read/write) only one value at a time
             *Saves to a single file location, can edit it
             * Web player has a size limit of 1MB
            What is it good for
              * USer/options setting
              * Controls
              * Audio
              * Resolution
     */

    public string example;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerPrefs.SetString("Test String", example);
            PlayerPrefs.SetFloat("Test Float", 1f);
            PlayerPrefs.SetInt("Test Int", 1);
            PlayerPrefs.Save();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            PlayerPrefs.DeleteAll();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayerPrefs.DeleteKey("Test String");
        }
    }

    private void Awake()
    {
        Debug.Log(PlayerPrefs.HasKey("Test String") ? "Test String Found" : "No Save Data");
    }

    private void Start()
    {
        example = PlayerPrefs.GetString("Test String","Umbrella");
    }
}
