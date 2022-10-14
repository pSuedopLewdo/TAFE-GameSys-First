using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
        public MenuStates menuStates;
        public GameObject[] panels;

        public void ChangePanel(MenuStates states)
        {
                switch (states)
                {
                        case MenuStates.AnyKey:
                                for (int i = 0; i < panels.Length; i++)
                                {
                                        panels[i].SetActive(false);
                                }
                                panels[0].SetActive(true);
                                break;
                        case MenuStates.Settings:
                                for (int i = 0; i < panels.Length; i++)
                                {
                                        panels[i].SetActive(false);
                                }
                                panels[2].SetActive(true);
                                break;
                        case MenuStates.MainMenu:
                                for (int i = 0; i < panels.Length; i++)
                                {
                                        panels[i].SetActive(false);
                                }
                                panels[1].SetActive(true);
                                break;
                        default:
                                panels[0].SetActive(true);
                                break;
                }
        }

        public void ChangeScene(int sceneIndex)
        {
                SceneManager.LoadScene(sceneIndex);
        }
        private void Start()
        {
                menuStates = MenuStates.AnyKey;
                panels[0].SetActive(true);
                panels[1].SetActive(false);
                panels[2].SetActive(false);
        }

        void Update()
        {
                if (menuStates == MenuStates.AnyKey)
                {
                        if (Input.anyKey)
                        {
                                ChangePanel(menuStates = MenuStates.MainMenu);
                        }
                }

                if (menuStates == MenuStates.MainMenu)
                {
                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                                menuStates = MenuStates.AnyKey;
                        }
                }
                if (menuStates == MenuStates.Settings)
                {
                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                                menuStates = MenuStates.MainMenu;
                        }
                }
        }

        #region Buttons

        public void PlayButton()
        {
                if (menuStates == MenuStates.MainMenu)
                {
                        ChangeScene(2);
                }
        }

        public void SettingsButton()
        {
                ChangePanel(menuStates = MenuStates.Settings);
        }

        public void Quit()
        {
                Application.Quit();
                Debug.Log("ApplicationQuit");
                
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #endif
        }

        public void BackToMain()
        {
                ChangePanel(menuStates = MenuStates.MainMenu);
        }

        #endregion
        
}

public enum MenuStates
{
        AnyKey,
        MainMenu,
        Settings,
}
