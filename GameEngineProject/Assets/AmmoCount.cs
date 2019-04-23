using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    private Stats ammoFromPlayer;

    void Awake()
    {
        ammoFromPlayer = GameObject.FindObjectOfType<Stats>();
    }

    void Update()
    {
        GetComponent<Text>().text = ammoFromPlayer.AmmoInPlayer.ToString();
    }
}
