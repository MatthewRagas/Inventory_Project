using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Default Inventory")]
public class Inventory : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    private InventoryDataBaseObject database;
    public List<InventorySlot> Container = new List<InventorySlot>();

    private void OnEnable()
    {
#if UNITY_EDITOR
        database = (InventoryDataBaseObject)AssetDatabase.LoadAssetAtPath(
            "Assets/Resources/Inventory Database.asset", typeof(InventoryDataBaseObject));
#else
        database = Resources.Load<InventoryDataBaseObject>("Database");
#endif
    }
    
    public Inventory()
    {
        Container.Capacity = 9;
    }

    /*AddItem checks if a picked up item can be added and if it can will either
     stack it with copy items or place it in a new inventory slot if there is space.
    the function returns a boolean of true or false letting me know whether or not there
    was an item added.*/
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
            Container.Add(new InventorySlot(database.GetId[_item], _item, _amount));
            addedItem = true;
        }

        //return true or false whether or not an item has or has not been added to inventory.
        return addedItem;
    }
    //sorts by type. All sorting functions are model the same as this but with out need for typID variable
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
            //prevents from checking out of bounds
            if (i <= 0)
            {
                i = 0;
            }

            slotA = _inventory.Container[i];
            slotB = _inventory.Container[i + 1];

            //check if sorting by consumable type
            if (_typeID == isConsumable)
            {
                //if item type is the same skip up two slots
                if (slotA.item.typeID == _typeID && _typeID == slotB.item.typeID)
                {
                    i++;
                }
                //if item further down the list if of correct item type, swap and move
                //backwards to check previous slots with new correct item
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
                
                if (i >= _inventory.Container.Count - 1)
                {
                    i = _inventory.Container.Count - 1;
                }
            }
        }

        return _inventory.Container;
    }

    public List<InventorySlot> SortQuantityHL(Inventory _inventory)
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
            
            if(slotA.amount < slotB.amount)
            {
                _inventory.Container[i] = slotB;
                _inventory.Container[i + 1] = slotA;
                i -= 2;
            }
        }

            return _inventory.Container;
    }

    public List<InventorySlot> SortQuantityLH(Inventory _inventory)
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

            if (slotA.amount > slotB.amount)
            {
                _inventory.Container[i] = slotB;
                _inventory.Container[i + 1] = slotA;
                i -= 2;
            }
        }

        return _inventory.Container;
    }

    public void OnBeforeSerialize()
    {
        //throw new System.NotImplementedException();       
    }

    public void OnAfterDeserialize()
    {
        
        for (int i = 0; i < Container.Count; i++)
        {
            Container[i].item = database.GetItem[Container[i].ID];
        }
    }

    //save to JSON file
    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    //Load inventory
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    //Different from typeID, used for loading which item it is specifically
    public int ID;
    //the item in the slot
    public InventoryObject item;
    //amount of item in the slot
    public int amount;

    //Constructor
    public InventorySlot(int _id, InventoryObject _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }

    //add an amount of an item to the slot
    public void AddAmount(int _amount)
    {
        amount += _amount;
    }
}
