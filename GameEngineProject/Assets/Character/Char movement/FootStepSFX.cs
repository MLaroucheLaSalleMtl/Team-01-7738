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
        aud.PlayOneShot(sfx[Random.Range(0, 2)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
