using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Inventory inventory;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>().item;
        if(item)
        {
            if(inventory.AddItem(item, 1))
            {
                Destroy(other.gameObject);
            }            
        }
    }

    private void Update()
    {
        
        //Increase ivnentory Capacity
        if(Input.GetKeyDown(KeyCode.Period))
        {
            inventory.Container.Capacity += 1;
        }

        /*Decrease inventory Capacity
         *and drop items that no longer fit
         */
        if(Input.GetKeyDown(KeyCode.Comma))
        {
            if(inventory.Container.Capacity == inventory.Container.Count)
            {
                int i = inventory.Container.Count - 1;
                if(RemoveItem())
                {
                    inventory.Container.Capacity -= 1;
                }                
            }
            else
            {
                inventory.Container.Capacity -= 1;
            }            
        }
    }

    //Removes item at highest index
    private bool RemoveItem()
    {
        bool itemRemoved = false;
        //holds previous value of count
        int previousCount = inventory.Container.Count;
        inventory.Container.RemoveAt(inventory.Container.Count - 1);

        //if count is now less than previousCount number
        //then the item has been removed
        if(previousCount > inventory.Container.Count)
        {
            //return true
            itemRemoved = true;
        }
        return itemRemoved;
    }
}
