using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Database")]
public class InventoryDataBaseObject : ScriptableObject, ISerializationCallbackReceiver
{
    public InventoryObject[] Items;
    public Dictionary<InventoryObject, int> GetId = new Dictionary<InventoryObject,int>();
    public Dictionary<int, InventoryObject> GetItem = new Dictionary<int, InventoryObject>();

    public void OnAfterDeserialize()
    {
        //throw new System.NotImplementedException();
        GetId = new Dictionary<InventoryObject, int>();
        for(int i = 0; i < Items.Length; i++)
        {
            GetId.Add(Items[i], i);
            GetItem.Add(i, Items[i]);
        }
    }

    public void OnBeforeSerialize()
    {
        //throw new System.NotImplementedException();
    }
}
