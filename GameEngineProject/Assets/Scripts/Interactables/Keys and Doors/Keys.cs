using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : PickupItem
{
    bool keyPickedUp = false;

    public bool KeyPickedUp { get => keyPickedUp; set => keyPickedUp = value; }

    protected override void InteractPickUp()
    {
        StartCoroutine(DisplayText(interactedText));
        keyPickedUp = true;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        Invoke("DestroyObject", 1f);
    }

    void DestroyObject()
    {
        interactText.text = string.Empty;
        Destroy(gameObject);
    }
}
