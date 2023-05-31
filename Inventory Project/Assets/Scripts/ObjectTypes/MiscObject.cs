using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item", menuName = "New Inventory Item/Misc")]
public class MiscObject : InventoryObject
{
    //misc objects only need to assign typeID
    private void Awake()
    {
        typeID = 4;
    }
}
