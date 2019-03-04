using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    private Vector3 playersPosition;

    [SerializeField] private Text interactText;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform targetNode;
    [SerializeField] private Animator animator;

    bool inPosition = false;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && inPosition)
        {
            TeleportToNewPosition();
            animator.SetBool("FadeIn/Out", true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.text = "Prees 'E' To open door";
            inPosition = true;
        }
    }


    void TeleportToNewPosition()
    {
        player.transform.position = targetNode.position;
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
}

