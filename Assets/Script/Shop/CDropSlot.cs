using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CDropSlot : CSlot, IDropHandler
{
    private CPlaySoundEvent soundEvent;
    private CDragState dragState;

    public void OnDrop(PointerEventData eventData)
    {
        dragState = CDragState.Instance;
        soundEvent = CPlaySoundEvent.Instance;

        if (dragState.isDragging)
        {
            soundEvent.PlayTradeItemOnSoundEffect();
            Debug.Log("drop");
            SetItem(dragState.item);
            dragState.SetDragStateNull();

        }
    }
}
