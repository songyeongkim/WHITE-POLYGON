using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMKItemApplyEvent : QItemApplyEvent
{
    public override void Start()
    {
        base.Start();

        EndQuestAdd += TicketHave;
    }

    public override void SetActiveState()
    {
        if(QuestClear)
            gameObject.SetActive(false);
    }

    private void TicketHave()
    {
        checkNextQuest.QuestStart = true;
        gameObject.SetActive(false);
    }
}
