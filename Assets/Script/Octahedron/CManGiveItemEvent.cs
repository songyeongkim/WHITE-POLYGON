using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CManGiveItemEvent : QItemEvent
{
    public override void Start()
    {
        base.Start();
        EndQuestAdd += AddItemEvent;
    }

    public override void OnMouseDown()
    {
        if (!QuestClear && QuestStart && CUIManager.Instance.uiCanInteract && !EventSystem.current.IsPointerOverGameObject())
        {
            if (gettableObj.gettableItem)
            {
                StartQuest();
                QuestClear = true;

                if (checkNextQuest != null)
                    checkNextQuest.QuestStart = true;
            }
        }
    }

   
}
