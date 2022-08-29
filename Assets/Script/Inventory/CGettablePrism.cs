using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGettablePrism : CGettableObj
{
    public int rotateState;
    private int inslotNum;

    public override void Start()
    {
        base.Start();
        additionalItemMethod += ChangeItemState;
        ChangeRotateState();
    }

    public void ChangeItemState()
    {
        inslotNum = inventory.m_nEmptyCellNum - 1;
        gettableItem = false;
    }

    public void ChangeRotateState()
    {
        if(!gettableItem)
        {
            for(int i=0;i< inventory.inventoryCells.Length;i++)
            {
                if(inventory.inventoryCells[i].item == itemPrefab.gameObject)
                {
                    inventory.inventoryCells[i].AddItem(this);
                }
            }
        }
            
    }
}
