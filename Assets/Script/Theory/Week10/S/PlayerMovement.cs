using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public void Move(PlayerData player, float deltaX, float deltaY)
    {
        player.PositionX += deltaX;
        player.PositionY += deltaY;
        Console.WriteLine($"{player.PlayerName} moved to ({player.PositionX}, {player.PositionY})");
    }
}
