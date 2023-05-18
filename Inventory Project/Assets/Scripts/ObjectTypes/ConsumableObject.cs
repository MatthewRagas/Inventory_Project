using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ConsumableType
{
    healthPot,
    manaPot,
    staminaPot,
}

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "New Inventory Item/Consumable")]
public class ConsumableObject : InventoryObject
{
    public int restoreAmount;
    public ConsumableType type;


    //public void Awake()
    //{
    //    type = ObjectType.Consumable;
    //}
}
