using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{
    private float rotationX;

    [SerializeField] float sensitivityX = 15f;
    [SerializeField] private float walkingSpeed = 1f;

    void Start()
    {
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            rotationX = transform.localEulerAngles.y + Input.GetAxis("Horizontal") * sensitivityX;
            transform.localEulerAngles = new Vector3(0, rotationX, 0);
            transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

        }
        else if (Input.GetAxis("Mouse X") > 0.1 || Input.GetAxis("Mouse X") < -0.1)
            transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * sensitivityX , 0);

        transform.Translate(0f, 0f, walkingSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }
}
