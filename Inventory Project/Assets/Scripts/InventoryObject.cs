using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*ObjectType was an enum set up to have Misc, Consumable, Equipment, and Resource
 but I ended up deviding these objectypes into subtypes. example is Equipment has
armor and weapons. when beginning to sort by type, I realized only the subtypes were
being used and the objectTypes were useless. All accept Miscellanious because there is
no subtype of Misc.*/
public enum ObjectType
{    
    Misc
}

public abstract class InventoryObject : ScriptableObject
{   
    //was supposed to be used for UI
    public Sprite icon;
    /*typeID is used to differentiate
     items based on what type they are*/
    public int typeID;
}
