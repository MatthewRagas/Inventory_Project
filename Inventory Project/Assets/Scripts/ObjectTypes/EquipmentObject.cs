using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//different equipment types
public enum EquipmentType
{
    Armor,
    Weapn,
}

public class EquipmentObject : InventoryObject
{
    //the variables that all equipment types share
    public EquipmentType type;
}
