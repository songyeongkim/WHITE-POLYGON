using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimEventReceiver : CComponent
{
    [SerializeField]
    private CQuestComponent questComponent;

    public void AnimStartQuest()
    {
        questComponent.StartQuest();
    }
}
