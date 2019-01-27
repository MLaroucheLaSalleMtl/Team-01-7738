using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraPosition : MonoBehaviour
{
    private Camera camera;

    [SerializeField] private GameObject cameraNewPosition;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camera.transform.position = cameraNewPosition.transform.position;
            camera.transform.rotation = cameraNewPosition.transform.rotation;
        }
    }
}
