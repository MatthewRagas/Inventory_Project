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
        
        //Change ivnentory Capacity
        if(Input.GetKeyDown(KeyCode.Period))
        {
            inventory.Container.Capacity += 1;
        }

        if(Input.GetKeyDown(KeyCode.Comma))
        {
            inventory.Container.Capacity -= 1;
        }
    }
}
