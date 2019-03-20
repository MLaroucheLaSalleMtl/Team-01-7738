using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public Transform camPivot;
    float heading = 0;
    public Transform cam;
    Vector2 input;


    void Update()
    {
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;
        camPivot.rotation = Quaternion.Euler(0, heading, 0);

        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camF.normalized;


        // transform.position += new Vector3(input.x, 0, input.y) * Time.deltaTime * 5; 

        transform.position += (camF * input.y + 0 * camR * input.x) * Time.deltaTime * 5;

    }
} 

