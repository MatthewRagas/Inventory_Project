using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Database")]
public class InventoryDataBaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    //array of InventoryObjects
    public InventoryObject[] Items;

    //These dictionaries are used to store items in inventory and their type id's for saving and loading
    //Double dictionary was used instead of nested for loop as choice of using more memory over performance
    public Dictionary<InventoryObject, int> GetId = new Dictionary<InventoryObject,int>();
    public Dictionary<int, InventoryObject> GetItem = new Dictionary<int, InventoryObject>();

    public void OnAfterDeserialize()
    {        
        //add inventoryObjects to item dictionary 
        //and add itemID to id dictionary
        GetId = new Dictionary<InventoryObject, int>();
        for(int i = 0; i < Items.Length; i++)
        {
            GetId.Add(Items[i], i);
            GetItem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize(){}
}
