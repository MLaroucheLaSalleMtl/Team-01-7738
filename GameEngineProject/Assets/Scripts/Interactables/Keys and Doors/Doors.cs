using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : Interactables
{
    private bool openFirstTime = true;

    private AudioSource audioSource;

    [SerializeField] protected bool usesKey;

    [SerializeField] protected Keys key;
    [SerializeField] protected Animator animator;
    [SerializeField] private GameObject player;
    [SerializeField] private  Transform targetNode;
    [SerializeField] private AudioClip openDoor;
    [SerializeField] private AudioClip unlockDoor;
    [SerializeField] private AudioClip lockedDoor;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected override void Interact()
    {
        if (usesKey)
            if (key.KeyPickedUp)
            {
                if (openFirstTime)
                {
                    audioSource.PlayOneShot(unlockDoor);
                    StartCoroutine(DisplayText(interactedText));
                    key.InventoryScript.Slots[key.Index].transform.GetComponentInChildren<InventoryItem>().IsUsed = true;
                    openFirstTime = false;
                }
                else
                    StartCoroutine(OpenDoor());              
            }
            else
            {
                StartCoroutine(DisplayText("DoOR is LocKed"));
                audioSource.PlayOneShot(lockedDoor);
            }
        else
        {
            StartCoroutine(OpenDoor());
        }
    }

     protected virtual IEnumerator OpenDoor()
    {
        animator.SetBool("FadeIn/Out", true);
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(openDoor);
        player.transform.position = targetNode.position;
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("FadeIn/Out", false);
    }

}
