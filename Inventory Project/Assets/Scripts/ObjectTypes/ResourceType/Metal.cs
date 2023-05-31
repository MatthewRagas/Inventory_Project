using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory Item", menuName = "New Inventory Item/Resource/Smithing")]
public class Metal : ResourceObject
{
    public bool isIngot;
    //assigning metal variables
    public void Awake()
    {
        type = ResourceType.Smithing;
        typeID = 3;
    }
}
