using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBearDollClickEvent : QClickEvent
{
    [Header("GetBearItem")]
    [SerializeField]
    private CGettableObj bear;

    public override void Start()
    {
        base.Start();
        StartQuestAdd += CanGetBear;
    }

    public void CanGetBear()
    {
        QuestClear = true;
        checkNextQuest.QuestStart = true;
        bear.gettableItem = true;
    }
}
