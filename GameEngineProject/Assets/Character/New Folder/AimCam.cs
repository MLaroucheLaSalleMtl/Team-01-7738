using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCam : MonoBehaviour
{
    private Camera cam;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(pos);
        target.position = ray.GetPoint(100);
    }
}
