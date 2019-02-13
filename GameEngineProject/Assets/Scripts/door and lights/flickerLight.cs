using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickerLight : MonoBehaviour
{
    public float minTime = 0.05f;
    public float maxTime = 1.2f;
    private float timer;
    private Light l;


    // Start is called before the first frame update
    void Start()
    {
        
        l = GetComponent<Light>();
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            l.enabled =! l.enabled;
           
            timer = Random.Range(minTime, maxTime);
        }

        
    }
}
