using UnityEngine;

public class Player : Character
{
    Vector3 _inputDirection;

    public void FixedUpdate()
    {
        Move(_inputDirection);
        Turn(_inputDirection);
        
    }
    public void Update()
    {
        HandleInput();
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            Enemy e = InFront as Enemy;
            if (e != null)
            {
                Attack(e);
            }
        }
    }
    private void HandleInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        _inputDirection = new Vector3(x, 0, y);
    }
    private void Attack(Enemy enemy) {
        enemy.TakeDamage(Damage);
        Debug.Log($"{Name} attacks {enemy.Name} for {Damage} damage.");
    }
 
}
