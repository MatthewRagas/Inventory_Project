using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "New Inventory Item/Equipment/Weapon")]
public class Weapon : EquipmentObject
{
    public int damage;
    //assigning weapon type variables
    public void Awake()
    {
        type = EquipmentType.Weapn;
        typeID = 2;

    }
}
