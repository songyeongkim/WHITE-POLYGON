using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBearItemApplyEvent : QItemApplyEvent
{
    [Header("BearItemApplyEvent")]
    [SerializeField]
    private QClickEvent clickTextEvent;
    [SerializeField]
    private CGettableObj ticketItem;

    [SerializeField]
    private GameObject cottonBear;
    [SerializeField]
    private GameObject no_cottonBear;

    public override void Start()
    {
        base.Start();
        StartQuestAdd += FullOfCotton;
        EndQuestAdd += AfterCottomApply;
    }

    public override void SetActiveState()
    {
        if(QuestClear)
        {
            FullOfCotton();
        }
    }

    private void FullOfCotton()
    {
        cottonBear.SetActive(true);
        no_cottonBear.SetActive(false);
    }

    private void AfterCottomApply()
    {
        clickTextEvent.talkableCharacter.DialogueNum++;
        ticketItem.AddItemEvent();
    }
}
