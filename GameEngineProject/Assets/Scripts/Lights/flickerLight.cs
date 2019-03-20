using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickerLight : MonoBehaviour
{
    public float minTime = 0.05f;
    public float maxTime = 1.2f;
    private float timer;
    private Light pointLight;
    private MeshRenderer mesh;

    void Start()
    {
        pointLight = GetComponentInChildren<Light>();
        mesh = GetComponent<MeshRenderer>();
        timer = Random.Range(minTime, maxTime);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            pointLight.enabled = !pointLight.enabled;
            mesh.enabled = !mesh.enabled;

            timer = Random.Range(minTime, maxTime);
        }
    }
}
