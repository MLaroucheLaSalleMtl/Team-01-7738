using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLight : MonoBehaviour
{
    private Light flash;

    private AudioClip turnOn;
    private AudioClip turnOff;

    void Start()
    {
        flash = GetComponent<Light>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

             if(flash.enabled == false)
             {
                flash.enabled = true;
               
                //audio.clip = turnOn;
                //audio.Play();
             }
        
            else
            {
                     flash.enabled = false;

                    //audio.clip = turnOff;
                    //audio.Play();

            }
        }
    }
}
