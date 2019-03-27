using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCam : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = target.transform.position;
        //Quaternion rot = target.transform.rotation;
        Ray ray = cam.ScreenPointToRay(new Vector3(500, 200, 0));
        target.position = ray.GetPoint(5);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    }
}
