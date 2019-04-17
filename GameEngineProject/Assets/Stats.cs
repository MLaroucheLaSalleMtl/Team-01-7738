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

    public IEnumerator TakeDamage(int damageTaken)
    {
        playerAudioSource.PlayOneShot(playerHurtSounds[Random.Range(0, playerHurtSounds.Length)]);
        health -= damageTaken;

        damageEffect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        damageEffect.SetActive(false);
    }
}
