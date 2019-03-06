using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSFX : MonoBehaviour
{
    [SerializeField] private AudioClip[] sfx;
    private AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "woodFloor")
        {
            aud.PlayOneShot(sfx[0]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
