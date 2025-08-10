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
        //Move();
        //Turn();
    }
    private void HandleInput()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        _inputDirection = new Vector3(x, 0, y);
    }

   
    public override void Move(Vector3 direction)
    {
        rb.linearVelocity =new Vector3(_inputDirection.x * movementSpeed,rb.linearVelocity.y, _inputDirection.z * movementSpeed);
    }
}
