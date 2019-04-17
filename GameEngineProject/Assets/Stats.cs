using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{


    [SerializeField] private float health = 100f;

    [SerializeField] private GameObject[] guns;

    public float Health { get => health; set => health = value; }

    private AudioSource playerAudioSource;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
    }
}
