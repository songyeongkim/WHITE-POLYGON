using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHero : CCharacter, ITalkable
{

    public void StartDialogue()
    {
        ShowDialogue();
    }

    public override void NextEvent()
    {
        base.NextEvent();
        questComponent.QuestStart = true;
    }
}
