using UnityEngine;

public class Block : MonoBehaviour
{
    public enum Type { Grass, Ground, Rock}
    public int IDBlock;
    public Type type;

    public void OnEnter() {
        Debug.Log("OnEnter");
    }
    public void OnExit()
    {
        Debug.Log("OnExit");
    }
    public void OnStay()
    {
        Debug.Log("OnStay");
    }
}
