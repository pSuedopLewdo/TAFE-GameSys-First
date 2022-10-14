using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _audioManager;
    
    // Start is called before the first frame update
    void Awake()
    {
        AudioManagerInstance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    
    public static AudioManager AudioManagerInstance
    {
        get { return _audioManager; }
        //get => _gameManger;
        private set
        {
            if (_audioManager == null)
            {
                _audioManager = value;
            }
            else if (_audioManager != value)
            {
                Debug.Log($"{nameof(GameManager)} instance already exists, destroy the other THERE CAN ONLY BE ONE");
                Destroy(value.gameObject);
            }
        }
    }
}
