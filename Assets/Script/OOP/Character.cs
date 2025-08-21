using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : Identity
{
    int _health;
    public int health
    {
        get { return _health; }
        protected set { _health = Mathf.Clamp(value, 0, maxHealth); }
    }
    public int maxHealth = 100;
    public int Damage = 10;
    public float movementSpeed;
    protected Animator animator;
    protected Rigidbody rb;
    Quaternion newRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    public void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0) { 
            Destroy(gameObject);
        }
    }
    public void Heal(int amount)
    {
        health += amount;
    }
    protected virtual void Turn(Vector3 direction)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 15f);

        if (rb.linearVelocity.magnitude < 0.1f || direction == Vector3.zero) return;
        newRotation = Quaternion.LookRotation(direction);
    }
    protected virtual void Move(Vector3 direction)
    {
        rb.linearVelocity = new Vector3(direction.x * movementSpeed, rb.linearVelocity.y, direction.z * movementSpeed);
        animator.SetFloat("Speed", rb.linearVelocity.magnitude);
    }

 
}
