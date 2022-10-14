using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    public bool dropdownEnabled;
    public GameObject dropdown;
    public void ResDropdownOn()
    {
        if (dropdownEnabled == false)
        {
            dropdown.SetActive(true);
        }
        else if (dropdownEnabled == true)
        {
            dropdown.SetActive(false);
            dropdownEnabled = false;
        }
        
    }
    
    //this is how you change quality settings
    public void Quality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;


}
    public Toggle fullscreenToggle;
    public Resolution[] resolutions;
    public Dropdown resDropdown;

    private void Start()
    {
        dropdownEnabled = false;
        dropdown.SetActive(false);
        
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        
        //List adds and removes for how many are in the inventory
        List<string> options = new List<string>();
        int curResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (!options.Contains(option))
            {
                options.Add(option);
                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    curResIndex = options.Count - 1;
                }
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = curResIndex;
        resDropdown.RefreshShownValue();
    }

    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width,res.height,Screen.fullScreen);
    }
}
