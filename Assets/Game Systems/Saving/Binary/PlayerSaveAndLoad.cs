using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveAndLoad : MonoBehaviour
{
    private static PlayerHandler player;

    private static void Save()
    {
        PlayerBinary.SaveData(player);
    }

    private static void Load()
    {
        player.gameObject.GetComponent<CharacterController>().enabled = false;
        PlayerData data = PlayerBinary.LoadData(player);
        player.name = data.playerName;
        //health, mana, stamina, exp, levels
        var transform1 = player.transform;
        
        transform1.position = new Vector3(data.pX, data.pY, data.pZ);
        transform1.rotation = new Quaternion(data.rX, data.rY, data.rZ, data.rW);
        player.gameObject.GetComponent<CharacterController>().enabled = true;
    }

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Save();
            Debug.Log("Saved Game");
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Load();
            Debug.Log("Loaded Game");
        }
    }
}
