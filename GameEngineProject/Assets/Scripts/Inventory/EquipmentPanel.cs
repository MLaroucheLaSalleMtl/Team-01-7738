using System;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{

    [SerializeField] Transform equipmentLotsParent;
    [SerializeField] EquipmentSlot[] EquipmentSlots;


    public event Action<Item> OnItemRightClickedEvent;

    private void Awake()
    {
        for (int i = 0; i < EquipmentSlots.Length; i++)
        {
            EquipmentSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
    }



    private void OnValidate()
    {
        EquipmentSlots = equipmentLotsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < EquipmentSlots.Length; i++)
        {
            if(EquipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquippableItem)EquipmentSlots[i].Item;
                EquipmentSlots[i].Item = item;
                return true; 

            }
        }
        previousItem = null;
        return false;


    }

    public bool RemoveItem(EquippableItem item )
    {
        for (int i = 0; i < EquipmentSlots.Length; i++)
        {
            if (EquipmentSlots[i].Item == item)
            {
               
                EquipmentSlots[i].Item = item;
                return true;

            }
        }

        
        return false;


    }

}
