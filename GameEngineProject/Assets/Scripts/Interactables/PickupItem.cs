using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactables
{
    protected Inventory inventoryScript;

    [SerializeField] protected GameObject itemButton;

    void Start()
    {
        inventoryScript = GameObject.FindObjectOfType<Inventory>();
    }

    protected override void Interact()
    {
        for (int i = 0; i < inventoryScript.Items.Length; i++)
        {
            if (inventoryScript.IsOccupied[i] == false)
            {
                AddItemToInventory(i);
                InteractPickUp();
                break;
            }
            else
            {
                StartCoroutine(DisplayText("InveNtory FuLl"));
            }
        }
    }

    void AddItemToInventory(int index)
    {
        Instantiate(itemButton, inventoryScript.Items[index].transform, false);
        inventoryScript.IsOccupied[index] = true;
    }

    protected virtual void InteractPickUp()
    {

    }
}
