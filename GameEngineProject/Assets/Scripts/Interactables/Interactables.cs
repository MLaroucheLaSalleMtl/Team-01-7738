using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactables : MonoBehaviour
{
    private bool inPosition;
    private bool isDisplayingText;

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
        if (Input.GetButtonDown("Interact") && inPosition && !isDisplayingText)
        {
            Interact();
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
        foreach (char letter in textToDisplay.ToCharArray())
        {
            interactText.text += letter;
            yield return new WaitForSeconds(0.005f);
        }

        if (Input.GetButtonDown("Interact"))
        {
            isDisplayingText = false;
            mikeControlCode.enabled = true; 
            StartCoroutine(displayTextCoroutine);
        }
    }

    protected virtual void Interact()
    {
        mikeControlCode.enabled = false;
        StartCoroutine(DisplayText(interactedText));
    }
}
