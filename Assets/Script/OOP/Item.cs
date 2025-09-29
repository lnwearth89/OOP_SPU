using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Item : Identity
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected Collider itemCollider;
    
    void Start()
    {
        itemCollider = GetComponent<Collider>();
        itemCollider.isTrigger = true;
    }

    public virtual void Hit(Collider other)
    {
            Debug.Log("Hit : " + GetInfo());
            Debug.Log($"{Name} is on X:{positionX} Y:{positionY}");
            if (player == null)
            {
                Debug.LogWarning("Item hit by non-player object: " + other.name);
                return;
            }
        
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Hit(other);
        }
    }
}
