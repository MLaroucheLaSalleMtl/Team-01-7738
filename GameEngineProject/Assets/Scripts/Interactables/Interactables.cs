﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactables : MonoBehaviour
{
    private bool inPosition;
    private bool isDisplayingText;
    protected bool interactedOnce;

    protected MikeControl mikeControlCode;
    private IEnumerator displayTextCoroutine;

    [SerializeField] protected Text interactText;
    [SerializeField] protected string enterText;
    [SerializeField] protected string interactedText;

    void Start()
    {
        mikeControlCode = GameObject.FindObjectOfType<MikeControl>();  
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact") && inPosition && !isDisplayingText && !interactedOnce)
        {
            Interact();
        }
        else if (Input.GetButtonDown("Interact") && interactedOnce && !isDisplayingText)
        {
            SecondInteract();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            displayTextCoroutine = DisplayText(enterText);
            StartCoroutine(displayTextCoroutine);
            inPosition = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inPosition = false;
            StopCoroutine(displayTextCoroutine);
            interactText.text = string.Empty;
        }
    }

    protected IEnumerator DisplayText(string textToDisplay)
    {
        isDisplayingText = true;

        interactText.text = string.Empty;
        yield return new WaitForSeconds(0.0005f);
        //foreach (char letter in textToDisplay.ToCharArray())
        //{
        //}

        interactText.text = textToDisplay;
        isDisplayingText = false;
    }

    protected virtual void Interact()
    {
        mikeControlCode.enabled = false;
        displayTextCoroutine = DisplayText(interactedText);
        StartCoroutine(displayTextCoroutine);
        interactedOnce = true;     
    }

    protected virtual void SecondInteract()
    {
        interactedOnce = false;
        mikeControlCode.enabled = true;
        interactText.text = string.Empty;
        displayTextCoroutine = DisplayText(enterText);
        StartCoroutine(displayTextCoroutine);
    }
}
