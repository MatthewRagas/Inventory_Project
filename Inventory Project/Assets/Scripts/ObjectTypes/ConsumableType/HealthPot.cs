using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthPot : ConsumableObject
{
    public int healAmount;

    public void Awake()
    {
        type = ConsumableType.healthPot;
    }
}
