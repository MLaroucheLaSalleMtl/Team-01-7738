using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactables
{
    private int index;

    protected Inventory inventoryScript;
    private InventoryItem item;

    [SerializeField] private GameObject itemButton;

    public int Index { get => index; set => index = value; }
    public Inventory InventoryScript { get => inventoryScript; set => inventoryScript = value; }

    void Start()
    {
        inventoryScript = GameObject.FindObjectOfType<Inventory>();
    }

    protected override void Interact()
    {
        for (int i = 0; i < inventoryScript.Slots.Length; i++)
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

    void AddItemToInventory(int index)
    {
        this.index = index;
        Instantiate(itemButton, inventoryScript.Slots[index].transform, false);
        inventoryScript.Slots[index].IsEmpty = false;
    }

    protected override void SecondInteract() { Destroy(gameObject); }
}
