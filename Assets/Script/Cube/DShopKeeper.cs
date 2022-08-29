using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DShopKeeper : CCharacter, ITalkable
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
