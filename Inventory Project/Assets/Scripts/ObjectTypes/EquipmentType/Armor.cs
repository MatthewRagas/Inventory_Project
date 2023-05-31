using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Inventory Item", menuName = "New Inventory Item/Equipment/Armor")]
public class Armor : EquipmentObject
{
    public int armor;
    //assigning armor type variables
    public void Awake()
    {
        type = EquipmentType.Armor;
        typeID = 2;
    }
}
