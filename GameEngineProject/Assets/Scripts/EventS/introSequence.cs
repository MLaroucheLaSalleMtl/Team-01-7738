using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class introSequence : MonoBehaviour
{
    private int index;
    private MikeControl mikeCode;
    private bool introFinish = false;

    [SerializeField] private float typingSpeed = 0.2f;

    [SerializeField] private string[] dialogues;
    [SerializeField] private Text dialogueText;
    [SerializeField] private Animator fadeAnimator;

    void Start()
    {
        mikeCode = GameObject.FindObjectOfType<MikeControl>().GetComponent<MikeControl>();
        mikeCode.enabled = false;
        dialogueText.text = string.Empty;
        fadeAnimator.SetBool("FadeIn/Out", true);
        Invoke("AnimatorIsFinished", 20f);
    }

    void Update()
    {
        if (dialogueText.text == dialogues[index])
        {
            if (Input.anyKey)
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
            mikeCode.enabled = true;
        }
    }

    void AnimatorIsFinished() { StartCoroutine(IntroDialogue()); }

}
