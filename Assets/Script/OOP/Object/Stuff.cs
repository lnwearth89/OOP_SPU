using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Stuff : Identity
{
    public TMP_Text interactionTextUI;
    protected Collider _collider;
    public bool isInteractable = true;
    private void Start()
    {
        interactionTextUI = GetComponentInChildren<TMP_Text>();
        _collider = GetComponent<Collider>();
    }
    public void Update()
    {
        if (DistanFormPlayer < 2f && isInteractable)
        {
            interactionTextUI.gameObject.SetActive(true);
        }
        else
        {
            interactionTextUI.gameObject.SetActive(false);
        }
    }

}
