using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractOnOff : Interactables
{

    [SerializeField] private Transform newPosition;
    [SerializeField] private GameObject toggleObject;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private string followUpText;

    [SerializeField] private bool onAndOff;
    [SerializeField] private bool moveObject;
    [SerializeField] private bool isToggleObject;
    [SerializeField] private bool isAudioSource;

    protected override void Interact()
    {
        
        if (Input.GetButtonDown("Interact"))
        {
            onAndOff = false; 
        }

        if (moveObject)
        {
            MoveObject();
        }

        if (isToggleObject)
            toggleObject.SetActive(onAndOff);
        if (isAudioSource)
            audioSource.enabled = onAndOff;            
    }
    
    void MoveObject()
    {
        Transform firstPosition = transform;

        transform.position = newPosition.position;
        transform.rotation = newPosition.rotation; 
       
        newPosition = firstPosition;
    }
}
