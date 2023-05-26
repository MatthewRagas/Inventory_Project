using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventorySlotUI : MonoBehaviour
{

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
