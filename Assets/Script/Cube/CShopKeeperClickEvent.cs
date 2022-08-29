using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShopKeeperClickEvent : QClickEvent
{
    [SerializeField]
    private GameObject tradeUI;

    public override void Start()
    {
        base.Start();
    }

    public override void CheckQuestNum()
    {
        talkableCharacter.dialogueUI.ChangeDialoguePos(dialogueStyle);
        talkableCharacter.ShowDialogue();

        if (talkableCharacter.DialogueNum ==  1)
        {
            EndDialogueAdd += ShowTradeUI;
            talkableCharacter.DialogueNum++;
        }
        else if (talkableCharacter.DialogueNum > 1)
        {
            EndDialogueAdd += ShowTradeUI;
        }
    }

    public void ShowTradeUI()
    {
        tradeUI.SetActive(true);
    }
}
