using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public Transform itemsParent;

    public Inventory inventory;

    InventorySlotUI[] slots;
    //public Item item;
    //public Image icon;

    // Start is called before the first frame update
    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlotUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateDisplay();
    }
    
    public void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.Container.Count)
            {
                slots[i].AddItem(inventory.Container[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}
