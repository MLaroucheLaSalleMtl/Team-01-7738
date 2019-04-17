using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : PickupItem
{
    bool keyPickedUp = false;

    public bool KeyPickedUp { get => keyPickedUp; set => keyPickedUp = value; }

    protected override void SecondInteract()
    {
        StartCoroutine(DisplayText(interactedText));
        keyPickedUp = true;
        GetComponent<MeshRenderer>().enabled = false;
        transform.position = new Vector3(0, 0, 0);
        Invoke("DestroyObject", 1f);
    }

    void DestroyObject()
    {
        interactText.text = string.Empty;       
    }
}
