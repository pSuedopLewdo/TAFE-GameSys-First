[System.Serializable]
/* 
  PlayerData is the bridge between your binary save script and your game
  */
public class PlayerData
{
    //Data we want to save
    //Position
    public float pX, pY, pZ;
    public float rX, rY, rZ, rW;
    //Player Stats
    public float curHealth, maxHealth, curMana, maxMana, curStamina, maxStamina, curExp, maxExp;
    public int level;
    //Name
    public string playerName;

    public PlayerData(PlayerHandler player)
    {
        playerName = player.name;
        
        level = 1;
        maxHealth = 100;
        maxExp = 100;
        maxMana = 100;
        maxStamina = 100;
        curHealth = 100;
        curExp = 100;
        curMana = 100;
        curStamina = 100;

        var transform = player.transform;
        var position = transform.position;
        var rotation = transform.rotation;
        
        pX = position.x;
        pY = position.y;
        pZ = position.z;
        
        rW = rotation.w;
        rX = rotation.x;
        rY = rotation.y;
        rZ = rotation.z;
    }
}
