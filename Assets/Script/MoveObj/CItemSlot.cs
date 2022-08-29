using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CItemSlot : CSlot,
    IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public CInvenCell itemCell;

    private CDragState dragState;

    private CPlaySoundEvent soundEvent;

    public override void Start()
    {
        base.Start();
        InventorySetting();
        soundEvent = CPlaySoundEvent.Instance;
    }


    public void InventorySetting()
    {
        itemCell = Function.FindComponent<CInvenCell>("InvenCell_" + slotNum.ToString());
        itemCell.itemSlot = this;

        if (itemCell.item != null)
        {
            itemCell.SetSlotItem();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            soundEvent.PlayButtonSoundEffect();
            dragState = CDragState.Instance;
            dragState.gameObject.SetActive(true);
            dragState.SetDragState(this);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(dragState.isDragging)
        {
            CUIManager.Instance.ApplyPointerCursorImg();
            dragState.image.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragState.isDragging)
        {
            CUIManager.Instance.ApplyNormalCursor();
            dragState.SetDragStateNull();
            //아이템 사용 여부 코드 추가 필요 -> 아이템 자체에 넣는 게 좋을듯?
        }
    }
}
