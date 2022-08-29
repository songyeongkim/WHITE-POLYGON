using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QItemApplyEvent : CQuestComponent, IStartActiveInfo
{
    public CDragState dragState;
    [SerializeField]
    protected CItem[] needItem;

    [SerializeField]
    protected CItem currentNeedItem;

    [SerializeField]
    private bool removeItemAfterApply = true;


    public void OnMouseEnter()
    {
        if (CDragState.Instance != null)
        {
            dragState = CDragState.Instance;
            if (dragState.isDragging)
            {
                if((rotationState != null && rotationState.rotationMatched) ||
                    rotationState == null)
                    dragState.canApplyObj = this;
            }
        }
    }

    public void OnMouseExit()
    {
        if (CDragState.Instance != null)
        {
            dragState = CDragState.Instance;
            if ((rotationState != null && rotationState.rotationMatched) ||
                    rotationState == null)
                dragState.canApplyObj = null;
        }
    }

    public virtual void ItemApplyEvent()
    {
        if(dragState.item == currentNeedItem && QuestStart)
        {
            Debug.Log("ItemApply");
            ItemApplySoundPlay();

            if (removeItemAfterApply)
                CInventory.Instance.RemoveItem(dragState.item);

            StartQuest();
        }   
    }

    public virtual void ItemApplySoundPlay()
    {
        playSoundEvent.PlayItemApplySoundEffect();
    }
}
