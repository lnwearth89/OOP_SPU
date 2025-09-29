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
            var e = InFront as Idestoryable;
            Attack(e);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            IInteractable e = InFront as IInteractable;
            Interact(e);
        }
    }
    private void HandleInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        _inputDirection = new Vector3(x, 0, y);
    }
    private void Interact(IInteractable interactable)
    {
        if (interactable != null)
        {
            interactable.Interact(this);
        }
    }
    private void Attack(Idestoryable thing) {
        animator.SetTrigger("Attack");
        if (thing != null)
        {
            thing.TakeDamage(Damage);
            Identity e = thing as Identity;
            Debug.Log($"{Name} attacks {e.Name} for {Damage} damage.");
        }
    }
   

}
