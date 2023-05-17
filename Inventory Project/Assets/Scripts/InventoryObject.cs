using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Equipment,
    Consumable,
    Resource,
    Misc,
}

public abstract class InventoryObject : ScriptableObject
{

    public new string name;
    public ObjectType type;
    public Sprite sprite;

}
