using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTradeSlotInfo : CSingleton<CTradeSlotInfo>
{
    public List<CItem> tradeItemList;

    public TradeList tradeList;

    public override void Start()
    {
        //tradeItemList = new List<CItem>();
        tradeList = new TradeList();
        tradeList.items = new List<CItem>();
    }
}




