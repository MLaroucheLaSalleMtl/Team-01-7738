using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] Text interactText;
    [SerializeField] Transform player;
    [SerializeField] Transform targetNode;
    [SerializeField] Animator animator;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.position = targetNode.position;
        }
    }


    //void Update()
    //{
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        interactText.text = "Prees 'E' To open door";
    //        if (Input.GetButtonDown("Fire1"))
    //        {
    //            animator.SetBool("FadeIn/Out", true);
    //            TeleportToNewPosition();
    //        }        
    //    }
    //}

    //void TeleportToNewPosition()
    //{
    //    player.position = new Vector3(player.position.x + 10, player.position.y, player.position.z);
    //        //targetNode.position;
    //    animator.SetBool("FadeIn/Out", false);
    //    Debug.Log("ISIDE AND INTERACTING");
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        interactText.text = string.Empty;
    //    }
    //}
}

