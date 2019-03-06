using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    private bool isDisplayingText;

    [SerializeField] private bool usesKey;

    [SerializeField] private Text interactText;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform targetNode;
    [SerializeField] private Animator animator;

    bool inPosition = false;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && inPosition)
        {
            if (EventSystem.Keys[0])
            {
                StartCoroutine(TeleportToNewPosition());
            }
            else if (usesKey)
            {
                StartCoroutine(DisplayText("Door is Locked"));
            }
            else
            {
                StartCoroutine(TeleportToNewPosition());
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (usesKey)
        {
            if (other.CompareTag("Player"))
            {
                inPosition = true;
                StartCoroutine(DisplayText("Prees 'E' To open door"));
            }
        }
        else if (!usesKey)
        {
            if (other.CompareTag("Player"))
            {
                inPosition = true;
                StartCoroutine(DisplayText("Prees 'E' To open door"));
            }
        }
    }


     IEnumerator TeleportToNewPosition()
    {
        animator.SetBool("FadeIn/Out", true);
        yield return new WaitForSeconds(0.5f);
        player.transform.position = targetNode.position;
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("FadeIn/Out", false);
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

