using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Different resource types
public enum ResourceType
{
    Construciton,
    Smithing,
}

public class ResourceObject : InventoryObject
{
    //the variables that all resource types share
    public ResourceType type;
}
