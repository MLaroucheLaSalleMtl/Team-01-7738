using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikeControl : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float rotationSpeed = 1f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Animator anim;

<<<<<<< Updated upstream
    public float Speed { get => speed; set => speed = value; }
    public Vector3 MoveDirection { get => moveDirection; set => moveDirection = value; }
=======
    //IK animation
    [SerializeField] private float weightPosition;
    [SerializeField] private float weightRotation;
    [SerializeField] private float weightLook;
    [SerializeField] private float weightBody;
    [SerializeField] private float weightHead;
    [SerializeField] private float weightEyes;
    [SerializeField] private float weightClamp;
    [SerializeField] private Transform myTarget;
>>>>>>> Stashed changes

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void OnAnimatorIK()
    {
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weightPosition);
        anim.SetIKPosition(AvatarIKGoal.RightHand, myTarget.position);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, weightRotation);
        anim.SetIKRotation(AvatarIKGoal.RightHand, myTarget.rotation);
        anim.SetLookAtPosition(myTarget.position);
        if (Input.GetButton("Fire2"))
        {
            anim.SetLookAtWeight(weightLook, weightBody, weightHead, weightEyes, weightClamp);
        }
    }

    void Update()
    {


        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            anim.SetFloat("h", Input.GetAxis("Horizontal"));

            if (Input.GetButton("Fire3") && Input.GetButton("Vertical"))
            {
                speed = 4f;
                anim.SetFloat("v", Input.GetAxis("Vertical"));
            }
            else
            {
                anim.SetFloat("v", Input.GetAxis("Vertical") * 0.5f);
                speed = 2f;
            }

            if (Input.GetAxis("Horizontal") < 0 && !Input.GetButton("Vertical"))
            {
                rotationSpeed = 1f;
            }
            else if (Input.GetAxis("Horizontal") > 0 && !Input.GetButton("Vertical"))
            {
                rotationSpeed = 1f;
            }
            else
                rotationSpeed = 2f;

            moveDirection = Vector3.zero;
            moveDirection.z = Input.GetAxis("Vertical");
            if (Input.GetButton("Fire2"))
            {
                anim.SetBool("Aim", true);
                //anim.SetFloat("h", 1f);
                //anim.SetFloat("v", 0.25f);
            }
            else
                anim.SetBool("Aim", false);

            if (anim.GetBool("Aim"))
            {
                transform.position = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
            }
            else
            {
                transform.Rotate(0f, Input.GetAxis("Horizontal") * rotationSpeed, 0f);
            }
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
