using UnityEngine;

public class Potion : Item
{
    public int healthAmount = 20;
    public override void Hit(Collider other)
    {
        base.Hit(other);
        player.Heal(healthAmount);
        Debug.Log("Potion consumed: " + healthAmount + " health restored.");
        Destroy(gameObject); 
    }
}
