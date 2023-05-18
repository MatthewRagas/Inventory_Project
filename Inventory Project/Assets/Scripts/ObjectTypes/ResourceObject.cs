using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    Construciton,
    Smithing,
}

public class ResourceObject : InventoryObject
{
    public ResourceType type;
}
