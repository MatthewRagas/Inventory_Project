using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Default Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    
    public Inventory()
    {
        Container.Capacity = 6;
    }
    public bool AddItem(InventoryObject _item, int _amount)
    {
        bool hasItem = false;
        bool addedItem = false;
        //checks if iteration of item is already in inventory
        for(int i = 0; i < Container.Count; i++)
        {            
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                addedItem = true;
                break;
            }
        }
        
        //check if there is space for new item, add to inventory
        if(!hasItem && Container.Count < Container.Capacity)
        {
            Container.Add(new InventorySlot(_item, _amount));
            addedItem = true;
        }

        return addedItem;
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
