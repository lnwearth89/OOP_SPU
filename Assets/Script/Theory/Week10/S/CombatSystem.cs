using System;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    public void TakeDamage(PlayerData player, int amount)
    {
        player.Health -= amount;
        Console.WriteLine($"{player.PlayerName} took {amount} damage. Health: {player.Health}");
        if (player.Health <= 0)
        {
            Console.WriteLine($"{player.PlayerName} has been defeated!");
        }
    }
}
