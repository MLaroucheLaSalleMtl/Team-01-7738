using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCamera : MonoBehaviour
{
    private Camera camera;
    private Vector3 previousCameraPosition;
    private Vector3 previousCameraRotation;

    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            camera.enabled = false;
            gameObject.GetComponent<Camera>().enabled = true;
            //previousCameraPosition = camera.transform.position;
            //previousCameraRotation = camera.transform.rotation.eulerAngles;
            //camera.transform.position = transform.position;
            //camera.transform.rotation = transform.rotation;
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            gameObject.GetComponent<Camera>().enabled = false;
            camera.enabled = true;
            //camera.transform.position = previousCameraPosition;
            //camera.transform.rotation = Quaternion.Euler(previousCameraRotation);
        }
    }
}
