using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "New Inventory Item/Consumable/Stamina Pot")]
public class StaminaPot : ConsumableObject
{
    public void Awake()
    {
        type = ConsumableType.staminaPot;
        typeID = 1;
    }
}
