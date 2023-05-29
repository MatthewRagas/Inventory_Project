using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory Item", menuName = "New Inventory Item/Resource/Smithing")]
public class Metal : ResourceObject
{
    public bool isIngot;

    public void Awake()
    {
        type = ResourceType.Smithing;
        typeID = 3;
    }
}
