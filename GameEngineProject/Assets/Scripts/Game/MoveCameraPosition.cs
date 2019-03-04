using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraPosition : MonoBehaviour
{
    private GameObject camera;

    [SerializeField] private int delay;
    [SerializeField] private GameObject cameraNewPosition;

    public GameObject CameraNewPosition { get => cameraNewPosition; set => cameraNewPosition = value; }

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (delay != 0)
            {
                Invoke("DelayTransform", delay);
            }
            else
            {
                camera.transform.position = CameraNewPosition.transform.position;
                camera.transform.rotation = CameraNewPosition.transform.rotation;
            }
        }
    }

    private void DelayTranform()
    {
        camera.transform.position = CameraNewPosition.transform.position;
        camera.transform.rotation = CameraNewPosition.transform.rotation;
    }
}
