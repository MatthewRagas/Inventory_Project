using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Default Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();    
    
    public Inventory()
    {
        Container.Capacity = 9;
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

    public List<InventorySlot> SortType(Inventory _inventory, int _typeID)
    {        
        InventorySlot slotA;
        InventorySlot slotB;

        int isConsumable = 1;
         int isEquipment = 2;
          int isResource = 3;
              int isMisc = 4;

        //iterate though inventory list
        for (int i = 0; i < _inventory.Container.Count - 1; i++)
        {
            if (i <= 0)
            {
                i = 0;
            }
            slotA = _inventory.Container[i];
            slotB = _inventory.Container[i + 1];

            //check if sorting by consumable type
            if (_typeID == isConsumable)
            {

                if (slotA.item.typeID == _typeID && _typeID == slotB.item.typeID)
                {
                    i++;
                }
                else if (slotB.item.typeID == _typeID && slotA.item.typeID != _typeID)
                {
                    _inventory.Container[i] = slotB;
                    _inventory.Container[i + 1] = slotA;
                    i -= 2;
                    
                }
            }
            //check if sorting by equipment type
            else if(_typeID == isEquipment)
            {
                if (slotA.item.typeID == _typeID && _typeID == slotB.item.typeID)
                {
                    i++;
                }
                else if (slotB.item.typeID == _typeID && slotA.item.typeID != _typeID)
                {
                    _inventory.Container[i] = slotB;
                    _inventory.Container[i + 1] = slotA;
                    i -= 2;
                    
                }
            }
            //check if sorting by resource type
            else if(_typeID == isResource)
            {
                if (slotA.item.typeID == _typeID && _typeID == slotB.item.typeID)
                {
                    i++;
                }
                else if (slotB.item.typeID == _typeID && slotA.item.typeID != _typeID)
                {
                    _inventory.Container[i] = slotB;
                    _inventory.Container[i + 1] = slotA;
                    i -= 2;
                    
                }
            }
            //check if sorting by misc type
            else if(_typeID == isMisc)
            {
                if (slotA.item.typeID == _typeID && _typeID == slotB.item.typeID)
                {
                    i++;
                }
                else if (slotB.item.typeID == _typeID && slotA.item.typeID != _typeID)
                {
                    _inventory.Container[i] = slotB;
                    _inventory.Container[i + 1] = slotA;
                    i -= 2;
                    
                }
            }
        }

        return _inventory.Container;
    }

    public List<InventorySlot> SortAZ(Inventory _inventory)
    {
        InventorySlot slotA;
        InventorySlot slotB;

        for(int i = 0; i < _inventory.Container.Count - 1; i++)
        {
            if (i <= 0)
            {
                i = 0;
            }
            else if (i >= _inventory.Container.Count - 1)
            {
                i = _inventory.Container.Count - 1;
            }
            slotA = _inventory.Container[i];
            slotB = _inventory.Container[i + 1];

            if (slotA.item.name[0] > slotB.item.name[0])
            {
                _inventory.Container[i] = slotB;
                _inventory.Container[i + 1] = slotA;
                i -= 2;
            }
            else if(slotB.item.name[0] == slotA.item.name[0])
            {
                for (int n = 0; n < slotA.item.name.Length; n++)
                {
                    if (slotB.item.name[n] < slotA.item.name[n])
                    {
                        _inventory.Container[i] = slotB;
                        _inventory.Container[i + 1] = slotA;
                        break;
                    }
                }
                i++;
            }
        }

        return _inventory.Container;
    }

    public List<InventorySlot> SortZA(Inventory _inventory)
    {
        InventorySlot slotA;
        InventorySlot slotB;

        for (int i = 0; i < _inventory.Container.Count - 1; i++)
        {
            
            if (i <= 0)
            {
                i = 0;
            }
            
            slotA = _inventory.Container[i];
            slotB = _inventory.Container[i + 1];

            if (slotA.item.name[0] < slotB.item.name[0])
            {
                _inventory.Container[i] = slotB;
                _inventory.Container[i + 1] = slotA;
                i -= 2;
            }
            else if (slotB.item.name[0] == slotA.item.name[0])
            {
                for(int n = 0; n < slotA.item.name.Length; n++)
                {
                    if (slotB.item.name[n] > slotA.item.name[n])
                    {
                        _inventory.Container[i] = slotB;
                        _inventory.Container[i + 1] = slotA;
                        break;
                    }
                    else if(slotB.item.name[n] < slotA.item.name[n])
                    {                        
                        break;
                    }

                }
                //i++;
                if (i >= _inventory.Container.Count - 1)
                {
                    i = _inventory.Container.Count - 1;
                }
            }
        }

        return _inventory.Container;
    }

    public List<InventorySlot> SortQuantityHL(List<InventorySlot> _container)
    {


        return Container;
    }

    public List<InventorySlot> SortQuantityLH(List<InventorySlot> _container)
    {


        return Container;
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
