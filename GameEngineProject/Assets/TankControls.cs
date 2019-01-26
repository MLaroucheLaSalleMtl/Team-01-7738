using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera-Control/Mouse Look")]
public class TankControls : MonoBehaviour
{
    [SerializeField] private enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    [SerializeField] RotationAxes axes = RotationAxes.MouseXAndY;

    [SerializeField] float sensitivityX = 15f;
    [SerializeField] float minimumX = -360f;
    [SerializeField] float maximumX = 360f;
    [SerializeField] private float walkingSpeed = 1f;

    void Start()
    {
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    void Update()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Horizontal") * sensitivityX;

            transform.Translate(0f, 0f, walkingSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

            transform.localEulerAngles = new Vector3(0, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
            transform.Rotate(0, Input.GetAxis("Horizontal") * sensitivityX, 0 );
        else
        {
            transform.Translate(0f, 0f, walkingSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        }

    }
}
