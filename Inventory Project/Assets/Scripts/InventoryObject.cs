using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{    
    Misc
}

public abstract class InventoryObject : ScriptableObject
{

    public new string name;
    public Sprite icon;
    public int typeID;    

}
