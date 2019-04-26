using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : PickupItem
{
    [SerializeField] private int addAmmoAmount;

    private Stats playerAmmo;

    void Start()
    {
        inventoryScript = GameObject.FindObjectOfType<Inventory>();
        playerAmmo = GameObject.FindObjectOfType<Stats>();
    }

    protected override void Interact()
    {
        for (int i = 0; i < inventoryScript.Slots.Length; i++)
        {
            if (inventoryScript.Slots[i].transform.Find("AmmoBox(Clone)"))
            {
                SecondInteract();
                break;
            }
            else
            {
                if (inventoryScript.Slots[i].IsEmpty == true)
                {
                    AddItemToInventory(i);
                    SecondInteract();
                    break;
                }
                else
                {
                    StartCoroutine(DisplayText("InveNtory FuLl"));
                }
            }
        }
    }

    protected override void SecondInteract()
    {
        StartCoroutine(DisplayText(interactedText));
        playerAmmo.AmmoInPlayer += addAmmoAmount;
        GetComponent<MeshRenderer>().enabled = false;
        transform.position = new Vector3(0, 0, 0);
        Invoke("DestroyObject", 1f);
    }

    void DestroyObject()
    {
        interactText.text = string.Empty;
    }
}
