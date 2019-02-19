using UnityEngine;


public class InventoryManager : MonoBehaviour
{

    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;

    private void Awake()
    {
        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromPanel;
    }

    private void EquipFromInventory(Item item)
    {
        if(item is EquippableItem)
        {
            Equip((EquippableItem)item);
        }
    }

    private void UnequipFromPanel(Item item)
    {
        if(item is EquippableItem)
        {
            Unequip((EquippableItem)item);
        }
    }


    public void Equip(EquippableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if(equipmentPanel.AddItem(item, out previousItem))
            {
                if(previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
                else
                {
                    inventory.AddItem(item);
                }
 

            }

        }
    }

    public void Unequip(EquippableItem item)
    {
        if(!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }

}
