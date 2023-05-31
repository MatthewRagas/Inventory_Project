using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory Item", menuName = "New Inventory Item/Resource/Construction")]
public class Wood : ResourceObject
{
    //assigning wood variables
    public void Awake()
    {
        type = ResourceType.Construciton;
        typeID = 3;
    }
}
