using UnityEngine;

public class Character : Identity
{
    protected Rigidbody rb;
    public float movementSpeed;
    Quaternion newRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage(int amount) { 
    
    }
    protected virtual void Turn(Vector3 direction)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 15f);

        if (rb.linearVelocity.magnitude < 0.1f || direction == Vector3.zero) return;
        newRotation = Quaternion.LookRotation(direction);
    }
    public virtual void Move(Vector3 direction)
    {
        int toX = (int)(positionX + direction.x);
        int toY = (int)(positionY + direction.y);
        int fromX = positionX;
        int fromY = positionY;

        if (HasPlacement(toX, toY))
        {
            InteractObject(toX, toY);
        }
        else
        {
            SetPosition(toX, toY);
            TakeDamage(1);
        }
    }
    public virtual void SetPosition(int toX, int toY)
    {
        mapGenerator.mapdata[positionX, positionY] = mapGenerator.empty;
        positionX = toX;
        positionY = toY;
        transform.position = new Vector3(positionX, positionY, 0);
    }
    protected virtual void InteractObject(int toX, int toY)
    {
        if (mapGenerator.ObjectInscene[toX, toY] != null)
        {
            mapGenerator.ObjectInscene[toX, toY].Hit();
        }
    }
    protected bool HasPlacement(int x, int y)
    {
        string mapData = mapGenerator.GetMapData(x, y);
        return mapData != string.Empty;
    }
}
