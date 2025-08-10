using UnityEngine;

public class Identity : MonoBehaviour
{
    public string Name;
    public int positionX;
    public int positionY;
    public Block Currentblock;
    protected MapGenerator mapGenerator;
    public void GetInfo() {
        Debug.Log("Name : " + Name + " Currentblock : " + Currentblock);
    }

    public virtual void Hit()
    {

    }
}
