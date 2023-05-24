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
            inventory.AddItem(item, 1);
            Destroy(other.gameObject);
        }
    }
}
