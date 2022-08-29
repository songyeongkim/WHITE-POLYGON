using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonaRisaClickEvent : QClickEvent
{
    [Header("QuestManage")]
    [SerializeField]
    private int nowQuestNum;

    [SerializeField]
    private CGettableObj monarisaFrame;

    [SerializeField]
    private QRotationEvent monarisaBlackBack;


    public override void Start()
    {
        base.Start();
    }

    public override void CheckQuestNum()
    {
        if (talkableCharacter.DialogueNum == 0)
        {
            talkableCharacter.dialogueUI.ChangeDialoguePos(dialogueStyle);
            talkableCharacter.ShowDialogue();
        }
        else if (talkableCharacter.DialogueNum == 1)
        {
            talkableCharacter.dialogueUI.ChangeDialoguePos(dialogueStyle);
            talkableCharacter.ShowDialogue();
            EndDialogueAdd += ChangeNextQuestDialogue;
        }
        else if(talkableCharacter.DialogueNum == 4 && rotationState.rotationMatched)
        {
            talkableCharacter.dialogueUI.ChangeDialoguePos(dialogueStyle);
            talkableCharacter.ShowDialogue();
            EndDialogueAdd += EnableGetMonaRisaFrame;
        }
        else if(talkableCharacter.DialogueNum == 5 && rotationState.rotationMatched)
        {
            talkableCharacter.dialogueUI.ChangeDialoguePos(dialogueStyle);
            talkableCharacter.ShowDialogue();

            monarisaBlackBack.gameObject.SetActive(true);
            monarisaBlackBack.transform.localPosition = new Vector3(0,1,0);
            monarisaBlackBack.QuestStart = true;

            gameObject.SetActive(false);
            QuestClear = true;
        }
        else
        {
            talkableCharacter.dialogueUI.ChangeDialoguePos(dialogueStyle);
            talkableCharacter.ShowDialogue();
        }
    }

    public void ChangeNextQuestDialogue()
    {
        checkNextQuest.talkableCharacter.DialogueNum = 1;
        talkableCharacter.DialogueNum = 3;
        EndDialogueAdd -= ChangeNextQuestDialogue;
    }

    public void EnableGetMonaRisaFrame()
    {
        monarisaFrame.gettableItem = true;
        talkableCharacter.DialogueNum = 5;
    }
}
