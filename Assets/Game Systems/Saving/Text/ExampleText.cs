using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class ExampleText : MonoBehaviour
{
    public bool append;
    public string[] whatWeAreSaving;
    public string[] whatWeAreSplitting;
    public string[] showStringsLoaded;
    public int showIntLoaded;
    public string path = "Assets/Game Systems/Resources/Save/Test.txt";

    void Write()
    {
        StreamWriter writer = new StreamWriter(path, append);
        for (int i = 0; i < whatWeAreSaving.Length; i++)
        {
            if (i < whatWeAreSaving.Length - 1)
            {
                writer.Write(whatWeAreSaving[i] + "|");
            }
            else
            {
                writer.Write(whatWeAreSaving[i]);
            }
        }


        // Content to write to file
            //Writer
          //  writer.Write(whatWeAreSaving);
            writer.Close();
            AssetDatabase.ImportAsset(path);
        }

        void Read()
        {
            //Reader
            StreamReader reader = new StreamReader(path);
            string tmpRead = reader.ReadLine();
            whatWeAreSplitting = tmpRead.Split('|');
            showStringsLoaded = new string[whatWeAreSplitting.Length - 1];
            for (int i = 0; i < showStringsLoaded.Length; i++)
            {
                showStringsLoaded[i] = whatWeAreSplitting[i];
            }

            string gasgg = whatWeAreSplitting[whatWeAreSplitting.Length - 1];
            showIntLoaded = int.Parse(gasgg);
            reader.Close();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Write();
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                Read();
            }
        }
}

