using UnityEngine;

public class Torch : Stuff, IInteractable
{
    public Torch() { 
        Name = "Torch";
    }
    public string InteractionText => throw new System.NotImplementedException();
    public GameObject Firelight;
    public bool isOn;

    public override void SetUP()
    {
        base.SetUP();
        Firelight.gameObject.SetActive(isOn);
    }
    public void Interact(Player player)
    {
        isOn = !isOn;
        Firelight.gameObject.SetActive(isOn);
    }

   
}
