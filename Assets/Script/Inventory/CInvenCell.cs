using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInvenCell : CComponent
{
    public GameObject item;
    public CItemSlot itemSlot;

    public void AddItem(CGettableObj a_gettableObj)
    {
        item = a_gettableObj.itemPrefab.gameObject;
        SetSlotItem();
    }

    public void AddItem(CItem a_Item)
    {
        item = a_Item.gameObject;
        SetSlotItem();
    }

    public void DeleteItem()
    {
        item = null;
        itemSlot.EmptySlot();
    }

    public void SetSlotItem()
    {
        itemSlot.SetItem(item.GetComponent<CItem>());
    }
}
