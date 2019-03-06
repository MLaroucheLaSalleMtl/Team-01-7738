using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class introSequence : MonoBehaviour
{
    private int index;

    [SerializeField] private float typingSpeed = 0.2f;

    [SerializeField] private string[] dialogues;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Animator fadeAnimator;

    void Start()
    {
        dialogueText.text = string.Empty;
        fadeAnimator.SetBool("FadeIn/Out", true);
        StartCoroutine(IntroDialogue());
    }

    void Update()
    {
        if (dialogueText.text == dialogues[index])
        {
            if (Input.GetButtonDown("Interact"))
            {
                NextDialogue(); 
            }
        }
    }
  
    IEnumerator IntroDialogue()
    {
        foreach (char letter in dialogues[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(1f);
    }

    void NextDialogue()
    {
        if (index < dialogues.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(IntroDialogue());
        }
        else
        {
            dialogueText.text = string.Empty;
            fadeAnimator.SetBool("FadeIn/Out", false);
        }
    }

}
