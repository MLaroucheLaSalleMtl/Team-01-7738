using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractOnOff : Interactables
{
    [SerializeField] private Transform newPosition;
    [SerializeField] private GameObject toggleObject;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject yesButton;
    [SerializeField] private GameObject noButton;

    //[SerializeField] private bool onAndOff;
    [SerializeField] private bool moveObject;
    [SerializeField] private bool isToggleObject;
    [SerializeField] private bool isAudioSource;

    protected override void Interact()
    {
        interactedOnce = true;
        StartCoroutine(DisplayText(interactedText));
        mikeControlCode.enabled = false;
    }
    
    void MoveObject()
    {
        Transform firstPosition = transform;

        transform.position = newPosition.position;
        transform.rotation = newPosition.rotation; 
       
        newPosition = firstPosition;
    }

    protected override void SecondInteract()
    {
        interactText.text = string.Empty;
        yesButton.SetActive(true);
        noButton.SetActive(true);
        interactedOnce = false;

    }

    public void OnAndOff(bool onAndOff)
    {

        if (isToggleObject)
            toggleObject.SetActive(onAndOff);
        if (isAudioSource)
            audioSource.enabled = onAndOff;

        yesButton.SetActive(false);
        noButton.SetActive(false);

        mikeControlCode.enabled = true;
    }
}
