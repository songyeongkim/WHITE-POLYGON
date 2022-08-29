using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QClickEvent : CQuestComponent
{

    public override void Start()
    {
        base.Start();
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

    public void OnMouseDown()
    {
        if(!QuestClear && QuestStart && CUIManager.Instance.CheckIfUICanInteract() && !EventSystem.current.IsPointerOverGameObject())
        {
            ClickSoundPlay();
            StartQuest();
        }
        else if (EventSystem.current.IsPointerOverGameObject())
        {
            //Debug.Log(EventSystem.current);
        }
    }

    public virtual void ClickSoundPlay()
    {
        playSoundEvent.PlayButtonSoundEffect();
    }
}
