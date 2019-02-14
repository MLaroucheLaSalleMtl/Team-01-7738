using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{ Helmet, Chest, Gloves, Boots, Weapon1, Weapon2, Accessory1, Accessory2}


[CreateAssetMenu]
public class EquippableItem : Item
{
    public int bouns_Attack;
    public int bonus_Defense;
    [Space]
    public float bonus_AttackPersent;
    public float bonus_DefensePersent;
    [Space]
    public EquipmentType EquipmentType;
}
