using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Default Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddItem(InventoryObject _item, int _amount)
    {
        bool hasItem = false;


        for(int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }


        if(!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public InventoryObject item;
    public int amount;

    //Constructor
    public InventorySlot(InventoryObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int _amount)
    {
        amount += _amount;
    }
}
