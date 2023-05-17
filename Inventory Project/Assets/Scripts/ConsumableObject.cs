using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "New Inventory Item/Consumable")]
//public enum consumabletype
//{
//    healthpot,
//    manapot,
//    staminapot,
//}

public class ConsumableObject : InventoryObject
{
    public int healthRestore;
    public int manaRestore;
    public int staminaRestore;

    public void Awake()
    {
        type = ObjectType.Consumable;
    }
}
