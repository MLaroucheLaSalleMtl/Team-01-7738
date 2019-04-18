using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimForCamera : MonoBehaviour {

    private Camera cam;
    [SerializeField] private Transform target;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(pos); //take 2D object and convert to ray
        target.position = ray.GetPoint(100); //a ray is just a line
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
    }
}
