using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSimpleEvent : QClickEvent
{
    public override void Start()
    {
        base.Start();
        EndQuestAdd += SetNextQuestTrue;
    }

    public void SetNextQuestTrue()
    {
        if(checkNextQuest != null)
        {
            checkNextQuest.QuestStart = true;
        }
    }
}
