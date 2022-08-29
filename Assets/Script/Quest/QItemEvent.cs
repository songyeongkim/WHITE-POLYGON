using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QItemEvent : CQuestComponent
{
    [Header("ItemEvent")]
    [SerializeField]
    protected CGettableObj gettableObj;
    [SerializeField]
    protected bool falseAfterGet = true;

    public override void Start()
    {
        base.Start();
        EndQuestAdd += AddItemEvent;

        if (QuestClear && falseAfterGet)
            gameObject.SetActive(false);
    }

    public void HideItem()
    {
        gameObject.SetActive(false);
    }

    public void OnMouseOver()
    {
        if (!QuestClear && QuestStart && CUIManager.Instance.CheckIfUICanInteract() && !EventSystem.current.IsPointerOverGameObject())
        {
            CUIManager.Instance.ApplyPointerCursorImg();
        }
    }

    public void OnMouseExit()
    {
        if (!QuestClear && QuestStart && CUIManager.Instance.CheckIfUICanInteract() && !EventSystem.current.IsPointerOverGameObject())
        {
            CUIManager.Instance.ApplyNormalCursor();
        }
    }

    public virtual void OnMouseDown()
    {
        if (!QuestClear && QuestStart && CUIManager.Instance.uiCanInteract && !EventSystem.current.IsPointerOverGameObject())
        {
            if(gettableObj.gettableItem)
            {
                StartQuest();
            } 
        }
    }

    public void AddItemEvent()
    {
        if (checkNextQuest != null)
            checkNextQuest.QuestStart = true;

        gettableObj.AddItemEvent();

        if (falseAfterGet)
            HideItem();
    }
}
