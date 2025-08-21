using UnityEngine;

public class Identity : MonoBehaviour
{
    public string _Name;
    public string Name { 
        get {
            if (string.IsNullOrEmpty(_Name))
            {
                _Name = gameObject.name;
            }
            else {
                gameObject.name = _Name;
            }
            return _Name;
        }
        set { _Name = value; }
    }
    public int positionX{
        get { 
            return Mathf.RoundToInt(transform.position.x); 
        }
        set {
            transform.position = new Vector3(value, transform.position.y, transform.position.z);
        }
    }
    public int positionY {
        get
        {
            return Mathf.RoundToInt(transform.position.y);
        }
        set
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, value);
        }
    }
    Player _player;
    protected Player player { 
        get {
            if (_player == null) {
                _player = FindAnyObjectByType<Player>();
                if (_player == null) {
                    Debug.LogWarning("No Player found in the scene.");
                }
            }
            return _player;
        }
    }

    private GameObject _IdentityInFront;
    public Identity InFront {
        get {
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 1f);
            if (hit.collider != null) {
                _IdentityInFront = hit.collider.gameObject;
            } else {
                    
                Debug.LogWarning("No block found InFront the Identity.");
                return null;
            }
            
            return _IdentityInFront.GetComponent<Identity>();
        }
    }
    protected float DistanFormPlayer { 
        get {
            if (player == null) {
                return float.MaxValue; // No player found, return a large distance
            }
            return Vector3.Distance(transform.position, player.transform.position);
        }
    }
         
    //protected MapGenerator mapGenerator;
    public string GetInfo() {

        return ("Name : " + Name +" x:" +positionX + " y:"+positionY);
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 1f);

    }


}
