using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikeControl : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float rotationSpeed = 2f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Animator anim;

    public float Speed { get => speed; set => speed = value; }
    public Vector3 MoveDirection { get => moveDirection; set => moveDirection = value; }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //    if (Input.GetButton("Fire2"))
        //    {
        //        anim.SetBool("Aim", true);
        //        anim.SetFloat("h", 0f);
        //        anim.SetFloat("v", 0f);
                
        //}
        //    else
        //        anim.SetBool("Aim", false);
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            anim.SetFloat("v", Input.GetAxis("Vertical"));
            anim.SetFloat("h", Input.GetAxis("Horizontal"));


            //if (Input.GetKeyDown("a") && !Input.GetButton("Vertical") && !Input.GetButton("Fire2"))
            //{
            //    anim.SetTrigger("LeftT");
            //}
            //if (Input.GetKeyDown("d") && !Input.GetButton("Vertical") && !Input.GetButton("Fire2"))
            //{
            //    anim.SetTrigger("RightT");
            //}

            //if (Input.GetButton("Fire3") && Input.GetButton("Vertical"))
            //{
            //    speed = 4.75f;
            //    anim.SetBool("Running", true);
            //}
            //else
            //{
            //    speed = 2.0f;
            //    anim.SetBool("Running", false);
            //}

            moveDirection = Vector3.zero;
            moveDirection.z = Input.GetAxis("Vertical");
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            //if (Input.GetButton("Jump"))
            //{
            //    moveDirection.y = jumpSpeed;
            //}
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
