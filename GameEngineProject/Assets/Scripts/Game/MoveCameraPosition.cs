using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraPosition : MonoBehaviour
{
    private GameObject camera;

    [SerializeField] private GameObject cameraNewPosition;

    public GameObject CameraNewPosition { get => cameraNewPosition; set => cameraNewPosition = value; }

    private void Start()
    {
        //camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera = Camera.main.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camera.transform.position = CameraNewPosition.transform.position;
            camera.transform.rotation = CameraNewPosition.transform.rotation;
        }
    }
}