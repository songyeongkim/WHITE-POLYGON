using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMonaRisa : CCharacter, ITalkable
{
    public void StartDialogue()
    {
        ShowDialogue();
    }

    public override void NextEvent()
    {
        questComponent.EndDialogue();
    }
}
