using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Box : Stuff, IInteractable, Idestoryable
{
    public string InteractionText => "";
    public GameObject DropItem;

    // ���ҧ private backing fields ����Ѻ health ��� maxHealth
    private int _health;
    private int _maxHealth = 25;

    public int health
    {
        get { return _health; }
        set { _health = Mathf.Clamp(value, 0, _maxHealth); }
    }

    public int maxHealth
    {
        get { return _maxHealth; }
        set { _maxHealth = value; }
    }

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
    }

    public void Interact(Player player)
    {
        rb.isKinematic = !rb.isKinematic;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Debug.Log(transform.position);
            GameObject g = Instantiate(DropItem, transform.position, Quaternion.identity);
            g.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            Destroy(gameObject);
        }
    }

}
