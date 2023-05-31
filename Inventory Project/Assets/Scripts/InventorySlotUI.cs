using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventorySlotUI : MonoBehaviour
{
    //I can not really tell you what is going on here
    //I can not seem to understand UI right now
    public Image icon;

    InventorySlot slot;

    public void AddItem(InventorySlot newSlot)
    {
        slot = newSlot;

        icon.sprite = slot.item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        slot = null;

        icon.sprite=null;
        icon.enabled = false;
    }
}
