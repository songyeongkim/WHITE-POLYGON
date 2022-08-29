using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDragState : CSingleton<CDragState>
{
    public Image image;
    public CItem item;
    public bool isDragging;
    public CItemSlot usingItemSlot;

    public QItemApplyEvent canApplyObj;

    public void SetDragState(CItemSlot a_ItemSlot)
    {
        isDragging = true;
        image.gameObject.SetActive(true);
        usingItemSlot = a_ItemSlot;
        image.sprite = a_ItemSlot.item.itemImg.sprite;
        item = a_ItemSlot.item;
    }

    public void SetDragStateNull()
    {
        if(canApplyObj != null)
        {
            canApplyObj.ItemApplyEvent();
        }
        image.gameObject.SetActive(false);
        item = null;
        isDragging = false;
        canApplyObj = null;
    }

    public override void Awake()
    {
        Canvas dragUI = gameObject.AddComponent<Canvas>();
        dragUI.renderMode = RenderMode.ScreenSpaceOverlay;
        dragUI.sortingOrder = 11;

        gameObject.AddComponent<CanvasGroup>();
        gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;

        gameObject.AddComponent<CanvasScaler>();
        gameObject.AddComponent<GraphicRaycaster>();
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        GameObject imgObj = Function.CreateGameObject("DraggingImg", gameObject);
        imgObj.layer = LayerMask.NameToLayer("Ignore Raycast");
        imgObj.tag = "DraggingObj";
        imgObj.AddComponent<Image>();
        image = imgObj.GetComponent<Image>();

        gameObject.SetActive(false);
    }


}
