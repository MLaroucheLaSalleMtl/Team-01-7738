using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    private int ammoInPlayer;
    private int ammoInGun;
    private Gun gun;

    public float Health { get => health; set => health = value; }
    public int AmmoInPlayer { get => ammoInPlayer; set => ammoInPlayer = value; }
    public int AmmoInGun { get => ammoInGun; set => ammoInGun = value; }

    private AudioSource playerAudioSource;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerAudioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;

        if (health <= 0)
        {
            gameManager.GameOver();
        }
    }
}
