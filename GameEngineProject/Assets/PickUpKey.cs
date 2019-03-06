using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpKey : MonoBehaviour
{
    private bool inPosition;
    private bool isDisplayingText;

    private EventSystem eventSystemCode;

    [SerializeField] private int index;

    [SerializeField] private Text interactText;
    [SerializeField] private string text;


    void Update()
    {
        if (Input.GetButtonDown("Interact") && inPosition && !isDisplayingText)
        {
            StartCoroutine(DisplayText("Got a Key"));
            EventSystem.Keys[index] = true;
            Destroy(gameObject, 1f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisplayText(text));
            inPosition = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.text = string.Empty;
            inPosition = false;
        }
    }

    IEnumerator DisplayText(string textToDisplay)
    {
        isDisplayingText = true;

        interactText.text = string.Empty;
        foreach (char letter in textToDisplay.ToCharArray())
        {
            interactText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }

        isDisplayingText = false;
    }
}
