using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class PlayerBinary
{
    public static void SaveData(PlayerHandler player)
    {
        //Reference to our binary formatter
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        //Location to save (path)
        string path = Application.persistentDataPath + "/" + "Flower_Texture" + ".jpeg";
        //string path = "Assets/Game Systems/Resources/Save/Flower_Texture.jpeg"
        
        //create a file at that file path
        FileStream stream = new FileStream(path, FileMode.Create);
        //what data are we writing
        PlayerData data = new PlayerData(player);
        //write that data from the serialized byte steam
        binaryFormatter.Serialize(stream, data);
        //are we dont with the action so close the byte stream and finish writing
        stream.Close();
    }

    public static PlayerData LoadData(PlayerHandler player)
    {
        //location of path
        string path = Application.persistentDataPath + "/" + "Flower_Texture" + ".jpeg";
        //if we have a file at that path
        if (File.Exists(path))
        {
            //Reference formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //open file at the path
            FileStream stream = new FileStream(path, FileMode.Open);
            //read data from file and deserialize the bytes in the stream
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //we are done with th action so now close it
            stream.Close();
            return data;
            //send the usable data to the playerData script
        }
        else
        {
            return null;
        }
    }
}
