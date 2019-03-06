using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainDoorEvent : MonoBehaviour
{
    private EventSystem eventSystemCode;

    private bool inPosition;
    private bool isDisplayingText;
    private bool beenToDoorOnce;

    [SerializeField] private Text interactText;
    [SerializeField] private string text;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && inPosition && !isDisplayingText)
        {
            if (eventSystemCode.HasMainKey)
            {

            }
            else
            {
                StartCoroutine(DisplayText("You need to find the Key"));
            }
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
