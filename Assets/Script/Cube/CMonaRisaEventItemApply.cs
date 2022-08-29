using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonaRisaEventItemApply : QItemApplyEvent
{
    [SerializeField]
    private GameObject MonaRisaPicInFrame;
    [SerializeField]
    private GameObject MonaRisaFrame;

    public override void Start()
    {
        StartQuestAdd += ShowMonaRisaFrame;
        base.Start();
    }

    public void ShowMonaRisaFrame()
    {
        MonaRisaFrame.SetActive(true);
        talkableCharacter.DialogueNum = 4;

        checkPrevQuest.QuestClear = true;

        checkNextQuest.QuestStart = true;
    }
}
