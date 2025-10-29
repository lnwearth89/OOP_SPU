using UnityEngine;

public class GameSaver : MonoBehaviour
{
    public void SaveProgress(PlayerData player)
    {
        Debug.Log($"Saving game for {player.PlayerName} to local file...");
        // Logic for saving player data to a file
    }
}
