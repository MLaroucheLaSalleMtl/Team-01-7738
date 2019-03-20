using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : Interactables
{
    bool keyPickedUp = false;

    public bool KeyPickedUp { get => keyPickedUp; set => keyPickedUp = value; }

    protected override void Interact()
    {
        StartCoroutine(DisplayText(interactedText));
        keyPickedUp = true;
        GetComponent<BoxCollider>().enabled = false;
        Invoke("DestroyObject", 1f);
    }

    void DestroyObject()
    {
        interactText.text = string.Empty;
        Destroy(gameObject);
    }
}
