using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //variable allowing us to hold any kind of inventory we want to make.
    public Inventory inventory;
    public float moveSpeed = 1;

    public void Start()
    {
        //Loads previously saved inventory
        inventory.Load();
        //Sorts inventory alphabetically for default sorting method
        inventory.SortAZ(inventory);
    }

    private void OnApplicationQuit()
    {        
        //saves inventory before closing application
        inventory.Save();
        //clears out inventory container after saving
        inventory.Container.Clear();
    }

    public void OnTriggerEnter(Collider other)
    {
        //variable = to the item of the object we are colliding with
        var item = other.GetComponent<Item>().item;
        //if the object we are colliding with has an item attatched, perform task
        if(item)
        {
            //calls add item function
            if(inventory.AddItem(item, 1))
            {
                //destroy game object in scene if the item has been added to inventory
                Destroy(other.gameObject);
            }            
        }
    }

    private void Update()
    {
        //player movement
        var movementHorizontal = Input.GetAxis("Horizontal");
        var movementVertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(movementHorizontal, 0, 0) * Time.deltaTime * moveSpeed;
        transform.position += new Vector3(0, 0, movementVertical) * Time.deltaTime * moveSpeed;


        //Increase ivnentory Capacity
        if (Input.GetKeyDown(KeyCode.Period))
        {
            inventory.Container.Capacity += 1;
        }

        /*Decrease inventory Capacity
        *and remove items that no longer fit*/
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            if(inventory.Container.Capacity == inventory.Container.Count)
            {                
                //checks if an item has been removed from the list to decrease the count.
                //Capacity of List can not be lower than the count.
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

        //call Sort items by consumable type when alpha1 is pressed
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventory.SortType(inventory, 1);
        }
        //call Sort items by equipment type when alpha2 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventory.SortType(inventory, 2);
        }
        //call Sort items by resource type when alpha3 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inventory.SortType(inventory, 3);
        }
        //call Sort items by Misc type when alpha4 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            inventory.SortType(inventory, 4);
        }
        //call Sort items Alphabetically when alpha5 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            inventory.SortAZ(inventory);
        }
        //call Sort items backwards alphabetically when alpha6 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            inventory.SortZA(inventory);
        }
        //call Sort items by High > Low quantity when alpha7 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            inventory.SortQuantityHL(inventory);
        }
        //call Sort items by Low > High quantity when alpha8 is pressed
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            inventory.SortQuantityLH(inventory);
        }
    }

    //Removes item at highest index
    private bool RemoveItem()
    {
        bool itemRemoved = false;
        //holds previous value of count
        int previousCount = inventory.Container.Count;
        //Function used through List functionality
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
