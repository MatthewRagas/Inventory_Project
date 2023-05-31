using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


//this is more UI, I gave up on this part
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
        UpdateUI();
    }
    
    public void UpdateUI()
    {
        GetComponentInChildren<Text>().text = null;
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            this.GetComponentInChildren<Text>().text += inventory.Container[i].item.name + ": " + inventory.Container[i].amount + "\n";
        }
         
    }

}
