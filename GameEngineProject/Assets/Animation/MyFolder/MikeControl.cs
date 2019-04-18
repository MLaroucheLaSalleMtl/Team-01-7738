using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikeControl : MonoBehaviour
{
    [SerializeField] float speed = 4;
    [SerializeField] float gravity = 20.0f;
    [SerializeField] float rotationSpeed = 1f;

    private Animator anim;
    private CharacterController control;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("h", Input.GetAxis("Horizontal"));
        anim.SetFloat("v", Input.GetAxis("Vertical"));


        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;
        //moveDirection.z = Input.GetAxis("Vertical");
        //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //moveDirection = transform.TransformDirection(moveDirection);
        //moveDirection = moveDirection * speed;
        //transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("Aim", true);
        }
        else
            anim.SetBool("Aim", false);

        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        control.Move(moveDirection * Time.deltaTime);
    }
}
