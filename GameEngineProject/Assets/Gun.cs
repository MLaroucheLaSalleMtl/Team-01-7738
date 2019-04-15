using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private int ammunition;
    private int bulletsInGun = 12;

    [SerializeField] private Transform shootPoint;
    [SerializeField] private Text bulletInGunCountText;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private AudioClip noAmmoSound;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AudioSource audioSource;
    private void Update()
    {
        bulletInGunCountText.text = bulletsInGun.ToString();

        if (Input.GetButton("Fire1"))
            Shoot();

        if (Input.GetButton("Reload"))      
            Reload();
    }

    private void Shoot()
    {
        if (ammunition > 0)
        {
            RaycastHit hit;

            if (Physics.Raycast(shootPoint.position, shootPoint.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(shootPoint.position, shootPoint.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }
        }
        else
        {

        }
    }

    private void Reload()
    {
        if (ammunition > 0 && bulletsInGun < 12)
        {
            for (int i = bulletsInGun; bulletsInGun < 12; i++)
            {
                ammunition--;
                bulletsInGun++;
            }
        }
    }
}
