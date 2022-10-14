using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class KeybindManager : MonoBehaviour
{
    [Serializable]
    public struct KeybindUI
    {
        public string inputName;
        public string keyDefaultValue;
        public string keyDisplayValue;
        public Text labelName;
        public Text keyDisplay;
    }

    [Header("References")]
    public GameObject keyPrefab;
    public GameObject keyContainer;
    public Color32 changedColour = new Color32(39, 171, 249, 255);
    public Color32 selectedColour = new Color32(239, 116, 36, 255);
    [SerializeField]
    public Dictionary<string, KeyCode> keycheinary = new Dictionary<string, KeyCode>();

    private GameObject _currentInput;
    [Space(8)]
    public KeybindUI[] inputKeys;
    
    

    private void Start()
    {
        for (int i = 0; i < inputKeys.Length; i++)
        {
            if (i > 0)
            {
                GameObject clone = Instantiate(keyPrefab, keyContainer.transform);
                inputKeys[i].labelName = clone.GetComponent<Text>();
                Text[] compsInChild = clone.GetComponentsInChildren<Text>();
                inputKeys[i].keyDisplay = compsInChild[1];
                clone.GetComponentInChildren<Button>().name = inputKeys[i].inputName;
            }

            inputKeys[i].labelName.text = inputKeys[i].inputName;
            inputKeys[i].keyDisplay.text = inputKeys[i].keyDefaultValue;
            keycheinary.Add(inputKeys[i].inputName, (KeyCode) Enum.Parse(typeof(KeyCode), inputKeys[i].keyDefaultValue));
        }

        foreach (var item in keycheinary)
        {
            Debug.Log(item.Key + " + " + item.Value);
        }
    }

    public void ChangeKey(GameObject clickedKey)
    {
        //_currentInput is the tmp holder to use outside of this function because clicked key is only within the curly bracers
        _currentInput = clickedKey;
        if (clickedKey != null)//if we have clicked the button
        {
            _currentInput.GetComponent<Image>().color = selectedColour;
        }
    }

    private void OnGUI()//this allows us to run events
    {
        string newKey = "";
        Event e = Event.current;
        Debug.Log(e.keyCode.ToString());
        if (_currentInput != null)
        {
             if (e.isKey)
             { 
                 newKey = e.keyCode.ToString();
             }
             else if (Input.GetKey(KeyCode.LeftShift)) 
             { 
                 newKey = "LeftShift";
             }
             else if (Input.GetKey(KeyCode.RightShift))
             {
                 newKey = "RightShift";
             } 
             if (newKey != "" )//null doesnt work in this scenario
             { 
                 keycheinary[_currentInput.name] = (KeyCode) Enum.Parse(typeof(KeyCode), newKey); 
                 _currentInput.GetComponentInChildren<Text>().text = newKey; 
                 _currentInput.GetComponent<Image>().color = changedColour; 
                 _currentInput = null;  //doesnt stay permanently selected
                 return;
             }
        }
    }
}
