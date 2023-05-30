using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{    
    Misc
}

public abstract class InventoryObject : ScriptableObject
{    
    public Sprite icon;
    public int typeID;
}
