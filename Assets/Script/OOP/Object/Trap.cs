using UnityEngine;

public class Trap : Stuff, IInteractable
{
    public string InteractionText => throw new System.NotImplementedException();
    public int Damage = 10;
    public GameObject spikes;
    public void Interact(Player player)
    {
        _collider.enabled = false;
        spikes.SetActive(false);
        isInteractable = false;
        Debug.Log("Trap Inactivated!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.TakeDamage(10);
        }
    }
}
