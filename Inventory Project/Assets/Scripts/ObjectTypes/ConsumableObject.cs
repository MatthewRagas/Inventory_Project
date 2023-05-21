using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ConsumableType
{
    healthPot,
    manaPot,
    staminaPot,
}

public class ConsumableObject : InventoryObject
{
    public int restoreAmount;
    public ConsumableType type;


    //public void Awake()
    //{
    //    type = ObjectType.Consumable;
    //}
}
