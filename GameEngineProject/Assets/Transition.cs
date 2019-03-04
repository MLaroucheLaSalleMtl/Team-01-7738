using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] Text interactText;
    [SerializeField] Transform player;
    [SerializeField] Transform targetNode;
    [SerializeField] Animator animator;

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportToNewPosition();
            interactText.text = "Prees 'E' To open door";
            if (Input.GetButton("Interact"))
            {
                Debug.Log("Inside and pressing E");
                animator.SetBool("FadeIn/Out", true);
            }
        }
    }

    void TeleportToNewPosition()
    {
        player.position = new Vector3(0,0,0);
        //targetNode.position;
        animator.SetBool("FadeIn/Out", false);
        Debug.Log("TELEPORTED");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.text = string.Empty;
        }
    }
}

