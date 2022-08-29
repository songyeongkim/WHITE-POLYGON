using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TradeList
{
    public List<CItem> items;

    public void RemoveItem(CItem targetItem)
    {
        items.Remove(targetItem);
    }

    public void AddItem(CItem targetItem)
    {
        items.Add(targetItem);
    }

    public void ResetItemList()
    {
        items.Clear();
    }

    public void CopyThisListToNew(TradeList a_tradeList)
    {
        a_tradeList.ResetItemList();

        for(int i=0;i<items.Count;i++)
        {
            a_tradeList.AddItem(items[i]);
        }
    }
}

public class CTradeSystem : CComponent
{
    public TradeList tradeList;
    public CTradeSlot tradeTarget;
    public CTradeSlot selectedSlot;
    public CDropSlot tradeCost;

    public CPlaySoundEvent soundEvent;


    [SerializeField]
    private CTradeSlot[] tradeSlots;
    [SerializeField]
    private GameObject tradeUI;

    private CTradeSlotInfo tradeSlotInfo;
    

    public override void Start()
    {
        tradeSlotInfo = CTradeSlotInfo.Instance;
        soundEvent = CPlaySoundEvent.Instance;

        if(tradeSlotInfo.tradeList.items.Count == 0)
        {
            UpdateSingleTurn();
        }

        SetListToSlot();
    }

    public void UpdateSingleTurn()
    {
        tradeList.CopyThisListToNew(tradeSlotInfo.tradeList);
    }

    public void SetListToSlot()
    {
        tradeList.ResetItemList();

        for (int i =0;i < tradeSlotInfo.tradeList.items.Count; i++)
        {
            tradeSlots[i].SetItem(tradeSlotInfo.tradeList.items[i]);
            tradeSlots[i].clickableSlot = true;
            tradeSlots[i].tradeSystem = this;

            tradeList.AddItem(tradeSlotInfo.tradeList.items[i]);
        }
    }

    public void TradeButton()
    {
        if(tradeTarget.item.CheckRequirement(tradeCost.item))
        {
            //trade -> user
            CDragState.Instance.usingItemSlot.itemCell.AddItem(tradeTarget.item);
            tradeList.RemoveItem(tradeTarget.item);

            //user -> trade
            selectedSlot.SetItem(tradeCost.item);
            tradeList.AddItem(tradeCost.item);

            soundEvent.PlayItemGetSoundEffect();

            UpdateSingleTurn();

            tradeTarget.EmptySlot();
            tradeCost.EmptySlot();
            Debug.Log("Trade Complete");
        }
    }

    public void TradeExitButton()
    {
        soundEvent.PlayButtonSoundEffect();
        tradeUI.SetActive(false);
    }
}
