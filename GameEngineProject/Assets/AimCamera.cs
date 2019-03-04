using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCamera : MonoBehaviour
{
    private Camera camera;
    private Transform previousCameraPosition;
    private MoveCameraPosition moveCameraScript;

    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        previousCameraPosition.position = moveCameraScript.CameraNewPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            camera.transform.position = transform.position;
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            camera.transform.position = previousCameraPosition.position;
        }
    }
}
