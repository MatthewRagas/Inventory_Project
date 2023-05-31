using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "New Inventory Item/Consumable/Mana Pot")]
public class ManaPot : ConsumableObject
{
    //assigning manapot variables
    public void Awake()
    {
        type = ConsumableType.manaPot;
        typeID = 1;
    }
}
