using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CInventory : CSingleton<CInventory>
{
    public CInvenCell[] inventoryCells;

    public int m_nEmptyCellNum = 0;

    public override void Awake()
    {
        inventoryCells = new CInvenCell[5];

        for (int i =0;i<5;i++)
        {
            GameObject itemCell = Function.CreateGameObject("InvenCell_" + i.ToString(), gameObject);
            Function.AddComponent<CInvenCell>(itemCell);
            inventoryCells[i] = itemCell.GetComponent<CInvenCell>();
        }
    }

    public GameObject FindItem(GameObject a_Item)
    {
        for(int i=0;i<inventoryCells.Length;i++)
        {
            if(inventoryCells[i].item == a_Item)
            {
                return inventoryCells[i].item;
            }
        }

        return null;
    }

    public void RemoveItem(CItem a_Item)
    {
        for(int i=0;i<5;i++)
        {
            if(inventoryCells[i].itemSlot.item == a_Item)
            {
                inventoryCells[i].DeleteItem();
                ResetSort();
                ResetSlotSetting();
                m_nEmptyCellNum--;
                if (m_nEmptyCellNum < 0)
                    m_nEmptyCellNum = 0;
            }
        }
    }

    public void ResetSort()
    {
        for(int i=0;i<4;i++)
        {
            if(inventoryCells[i].item == null && inventoryCells[i+1].item != null)
            {
                inventoryCells[i].AddItem(inventoryCells[i + 1].item.GetComponent<CGettableObj>());
                inventoryCells[i + 1].DeleteItem();
            }
        }
    }

    public void ResetSlotSetting()
    {
        for(int i=0;i<5;i++)
        {
            inventoryCells[i].itemSlot.InventorySetting();
        }
    }
}
