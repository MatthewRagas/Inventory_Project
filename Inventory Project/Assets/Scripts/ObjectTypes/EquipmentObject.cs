using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentType
{
    Armor,
    Weapn,
}

public class EquipmentObject : InventoryObject
{
   public EquipmentType type;
}
