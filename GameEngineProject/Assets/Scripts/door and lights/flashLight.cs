using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLight : MonoBehaviour
{
    //[SerializeField] private Light flash;


    [SerializeField] Light flash;

    private AudioClip turnOn;
    private AudioClip turnOff;



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
