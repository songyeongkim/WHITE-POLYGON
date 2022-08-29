using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QStartQuest : CQuestComponent
{
    public override void Start()
    {
        base.Start();
        if (!QuestClear && QuestStart)
        {
            StartQuest();
        }
    }
}
