using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string PlayerName;
    public int Health;
    public float PositionX;
    public float PositionY;

    public PlayerData(string name)
    {
        PlayerName = name;
        Health = 100;
        PositionX = 0;
        PositionY = 0;
    }
}
