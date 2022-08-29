using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class CSlot : CComponent, IPointerEnterHandler, IPointerExitHandler
{
    public CItem item;

    [SerializeField]
    private Outline outline;

    [SerializeField]
    protected Image itemImg;

    [SerializeField]
    protected int slotNum;

    private CUIManager uIManager;

    public override void Start()
    {
        uIManager = CUIManager.Instance;
    }

    public void SetItem(CItem a_Item)
    {
        item = a_Item;
        itemImg.gameObject.SetActive(true);
        itemImg.sprite = a_Item.itemImg.sprite;
    }

    public void EmptySlot()
    {
        item = null;
        itemImg.sprite = null;
        itemImg.gameObject.SetActive(false);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            if(outline != null)
                outline.enabled = true;
            uIManager.ApplyPointerCursorImg();
            uIManager.ShowItemName(item.itemName);
        }
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (outline != null)
            outline.enabled = false;
        uIManager.ApplyNormalCursor();
        uIManager.HideItemName();
    }

    
}
