using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "New Inventory Item/Consumable/Health Pot")]
public class HealthPot : ConsumableObject
{
    //assigning healthpot variables
    public void Awake()
    {
        type = ConsumableType.healthPot;
        typeID = 1;
    }

}
