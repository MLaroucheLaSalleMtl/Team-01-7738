using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    //To move
    private Animator anim;
    private Vector3 moveDirection = Vector3.zero;

    private float rotationX = 15f;
    [SerializeField] private float walkingSpeed = 1f;
    [SerializeField] private float sensitivityX = 15f;

    //IK animation
    [SerializeField] private float weightPosition;
    [SerializeField] private float weightRotation;
    [SerializeField] private float weightLook;
    [SerializeField] private float weightBody;
    [SerializeField] private float weightHead;
    [SerializeField] private float weightEyes;
    [SerializeField] private float weightClamp;
    [SerializeField] private Transform myTarget;

    private void OnAnimatorIK()
    {
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weightPosition);
        anim.SetIKPosition(AvatarIKGoal.RightHand, myTarget.position);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, weightRotation);
        anim.SetIKRotation(AvatarIKGoal.RightHand, myTarget.rotation);
        anim.SetLookAtWeight(weightLook, weightBody, weightHead, weightEyes, weightClamp);
        anim.SetLookAtPosition(myTarget.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a") && !Input.GetButton("Vertical"))
        {
            anim.SetTrigger("LeftT");
        }
        if (Input.GetKeyDown("d") && !Input.GetButton("Vertical"))
        {
            anim.SetTrigger("RightT");
        }

        anim.SetFloat("v", Input.GetAxis("Vertical"));
        anim.SetFloat("h", Input.GetAxis("Horizontal"));
        if (Input.GetButton("Fire3") && Input.GetButton("Vertical"))
        {
            anim.SetBool("Running", true);
        }
        else
            anim.SetBool("Running", false);
        moveDirection = Vector3.zero;

        //if (Input.GetButton("Horizontal") && Input.GetAxis("Vertical") > 0)
        //{
        //    rotationX = transform.localEulerAngles.y + Input.GetAxis("Horizontal") * sensitivityX;
        //    transform.localEulerAngles = new Vector3(0, rotationX, 0);
        //    transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        //}
        //else if (Input.GetAxis("Mouse X") > 0.1 || Input.GetAxis("Mouse X") < -0.1)
        //    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);

        //transform.Translate(0f, 0f, walkingSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
