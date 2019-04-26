using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : PickupItem
{
    [SerializeField] private GameObject gun;

    protected override void SecondInteract()
    {
        gun.SetActive(true);
        Destroy(gameObject);
    }
}
