using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //this is a singleton
    //static private ref to this script
    private static GameManager _gameManager;

    //currentState
    public GameState currentState = GameState.GameState;
    //properties
    public static GameManager GameManagerInstance
    {
        get { return _gameManager; }
        //get => _gameManger;
        private set
        {
            if (_gameManager == null)
            {
                _gameManager = value;
            }
            else if (_gameManager != value)
            {
                Debug.Log($"{nameof(GameManager)} instance already exists, destroy the other THERE CAN ONLY BE ONE");
                Destroy(value);
            }
        }
    }

    void Start()
    {
        currentState = GameState.GameState;
    }

    void Update()
    {
        switch (currentState)
        {
            case GameState.MenuState:
                if (Cursor.visible == false)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
            
            case GameState.GameState:
                if (Cursor.visible == true)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                break;
            
            case GameState.DeathState:
                if (Cursor.visible == false)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                break;
        }
    }

    void Awake()
    {
        GameManagerInstance = this;
    }
}

//Makes this Global
public enum GameState
    //change code based on which state, like unfreeze mouse or cursor invisible
{
    MenuState,
    GameState,
    DeathState,
}