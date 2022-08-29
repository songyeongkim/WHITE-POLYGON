using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DKnight : CCharacter, ITalkable
{
    public void StartDialogue()
    {
        ShowDialogue();
    }

    public override void NextEvent()
    {
        if (DialogueNum >= dialogue.Length)
        {
            questComponent.EndQuest();
        }
        else
        {
            questComponent.EndDialogue();
        }
    }
}
