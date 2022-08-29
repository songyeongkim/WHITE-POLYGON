using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CTradeSlot : CSlot, IPointerClickHandler
{
    public bool clickableSlot = false;
    public CTradeSystem tradeSystem;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(clickableSlot)
        {
            tradeSystem.soundEvent.PlayButtonSoundEffect();
            tradeSystem.tradeTarget.SetItem(item);
            tradeSystem.selectedSlot = this;
        }
    }
}
