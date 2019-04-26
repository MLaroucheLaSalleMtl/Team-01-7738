using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private int ammunition;
    private int bulletsInGun = 12;

    private Text bulletInGunCountText;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject shootPoint;
    [SerializeField] private AudioClip fireSound;
    [SerializeField] private AudioClip noAmmoSound;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject bulletShot;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bloodImapctEffect;
    [SerializeField] private GameObject bulletHole;
    [SerializeField] private GameObject expulseBulletChamber;

    void Awake()
    {
        Invoke("FindText", 0.5f);
    }

    private void Update()
    {
        if (bulletInGunCountText)
        {
            bulletInGunCountText.text = bulletsInGun.ToString();
        }

        if (Input.GetButtonDown("Fire1") && Time.timeScale == 1)
            animator.SetTrigger("Shoot");

        if (Input.GetButtonDown("Reload"))
            Reload();
    }

    private void Shoot()
    {

        if (bulletsInGun > 0)
        {
            bulletsInGun--;
            shootPoint.GetComponent<ParticleSystem>().Play();
            audioSource.PlayOneShot(fireSound);

            GameObject bulletInstance = Instantiate(bulletShot, shootPoint.transform.position, shootPoint.transform.rotation);
            bulletInstance.GetComponent<Rigidbody>().AddForce(transform.right * 100, ForceMode.Impulse);

            GameObject bulletShell = Instantiate(bullet, expulseBulletChamber.transform.position, expulseBulletChamber.transform.rotation);
            bulletShell.GetComponent<Rigidbody>().AddForce(((transform.right * Random.Range(1.5f, 2)) + expulseBulletChamber.GetComponent<Rigidbody>().velocity), ForceMode.Impulse);

            RaycastHit hit;

            if (Physics.Raycast(shootPoint.transform.position, shootPoint.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(shootPoint.transform.position, shootPoint.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");

                Monster monster = hit.transform.GetComponent<Monster>();

                if (monster != null)
                {
                    monster.TakeDamage(20);
                }

                if (hit.collider.CompareTag("Monster"))
                    Instantiate(bloodImapctEffect, hit.point, Quaternion.LookRotation(hit.normal));
                else
                {
                    //GameObject bHole = Instantiate(bulletHole, new Vector3(hit.point.x, hit.point.y, hit.point.z - 0.05f), Quaternion.FromToRotation(Vector3.up, hit.normal));
                    //Destroy(bHole, 20);
                }
            }
        }
    }

    void Reload()
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

    void FindText()
    {
        if (GameObject.FindGameObjectWithTag("BulletCount"))
        {
            bulletInGunCountText = GameObject.FindGameObjectWithTag("BulletCount").GetComponent<Text>();
        }
    }
}
