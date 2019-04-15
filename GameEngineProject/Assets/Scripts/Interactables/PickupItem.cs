using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactables
{
    protected Inventory inventoryScript;
    private InventoryItem item;

    [SerializeField] protected GameObject itemButton;
    [SerializeField] protected InventoryItem itemButtonn;

    void Start()
    {
        inventoryScript = GameObject.FindObjectOfType<Inventory>();
    }

    protected override void Interact()
    {
        for (int i = 0; i < inventoryScript.Slots.Length; i++)
        {
            Debug.Log(i);
            Debug.Log(inventoryScript.IsOccupied[i].ToString());
            if (inventoryScript.IsOccupied[i] == false)
            {
                AddItemToInventory(i);
                SecondInteract();
                Debug.Log(inventoryScript.IsOccupied[i].ToString());
                break;
            }
            else
            {
                Debug.Log(inventoryScript.IsOccupied[i].ToString());
                StartCoroutine(DisplayText("InveNtory FuLl"));
            }
        }
    }

    void AddItemToInventory(int index)
    {
        Instantiate(itemButton, inventoryScript.Slots[index].transform, false);
        inventoryScript.IsOccupied[index] = true;
    }

    protected override void SecondInteract() { }
}
