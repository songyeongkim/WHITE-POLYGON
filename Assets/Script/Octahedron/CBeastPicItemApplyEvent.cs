using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBeastPicItemApplyEvent : QItemApplyEvent, IStartActiveInfo
{
    [Header("BeastPicItemApplyEvent")]
    [SerializeField]
    private GameObject museumKeeper;
    [SerializeField]
    private GameObject lionNoClaw;
    [SerializeField]
    private GameObject lionClaw;


    public override void Start()
    {
        base.Start();
        StartQuestAdd += ClawApplyComplete;
    }

    private void ClawApplyComplete()
    {
        lionClaw.SetActive(true);
        lionNoClaw.SetActive(false);
        checkPrevQuest.talkableCharacter.DialogueNum++;
        checkNextQuest.talkableCharacter.DialogueNum++;
        checkNextQuest.talkableCharacter.autoQuestEnd = true;
    }

    public override void SetActiveState()
    {
        if(QuestClear)
        {
            lionClaw.SetActive(true);
            lionNoClaw.SetActive(false);
        }
    }
}
