using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikeControl : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        // let the gameObject fall down
        //gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            anim.SetFloat("v", Input.GetAxis("Vertical"));
            anim.SetFloat("h", Input.GetAxis("Horizontal"));

            if (Input.GetKeyDown("a") && !Input.GetButton("Vertical"))
            {
                anim.SetTrigger("LeftT");
            }
            if (Input.GetKeyDown("d") && !Input.GetButton("Vertical"))
            {
                anim.SetTrigger("RightT");
            }

            if (Input.GetButton("Fire3") && Input.GetButton("Vertical"))
            {
                anim.SetBool("Running", true);
            }
            else
                anim.SetBool("Running", false);

            moveDirection = Vector3.zero;
            moveDirection.z = Input.GetAxis("Vertical");
            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            transform.Rotate(0, Input.GetAxis("Horizontal") * 4, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
