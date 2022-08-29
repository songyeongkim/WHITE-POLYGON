using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSimpleText : CCharacter, ITalkable
{
    public void StartDialogue()
    {
        ShowDialogue();
    }

    public override void NextEvent()
    {
        if(autoQuestEnd)
        {
            DialogueNum++;

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
}
