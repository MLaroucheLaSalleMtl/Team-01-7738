using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : MonoBehaviour
{
    private EventSystem eventSystem;
    private AudioSource audioSource;

    [SerializeField] private GameObject newPosition;
    [SerializeField] private AudioClip sound;

    [SerializeField] private bool disapearObject;
    [SerializeField] private bool appearObject;
    [SerializeField] private bool makesLightFlicker;
    [SerializeField] private bool movesObjects;
    [SerializeField] private bool makeSound;

    void Start()
    {
        eventSystem = GameObject.FindObjectOfType<EventSystem>().GetComponent<EventSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (eventSystem.Event2)
        {
            if (disapearObject)
            {
                gameObject.SetActive(false);
            }
            else if (appearObject)
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            else if (makesLightFlicker)
            {
                if (gameObject.GetComponent<flickerLight>())
                {
                    gameObject.GetComponent<flickerLight>().enabled = true;
                }
            }
            else if (movesObjects)
            {
                transform.position = newPosition.transform.position;
                transform.rotation = newPosition.transform.rotation;
            }
            else if (makeSound)
            {
                audioSource.Play();
            }
        }
    }
}
