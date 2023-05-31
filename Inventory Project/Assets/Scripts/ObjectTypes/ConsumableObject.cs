using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//different types of Consumables
public enum ConsumableType
{
    healthPot,
    manaPot,
    staminaPot,
}

public class ConsumableObject : InventoryObject
{
    //the variables that all consumable types share
    public int restoreAmount;
    public ConsumableType type;    
}
