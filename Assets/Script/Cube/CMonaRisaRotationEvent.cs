using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonaRisaRotationEvent : QRotationEvent
{
    public override void UpdateObserver(CCube cube)
    {
        if (windowRotationStateCheck.FrontWallCheck() && windowRotationStateCheck.CheckRotationIsSetted()
            && cubeRotationStateCheck.FrontWallCheck())
        {
            rotationMatched = true;

            if (talkableCharacter.DialogueNum == 0 && !QuestClear)
            {
                RotateQuestClear(1);
            }
            else if(talkableCharacter.DialogueNum < 4)
                talkableCharacter.DialogueNum = 3;
        }
        else
        {
            rotationMatched = false;

            if (QuestClear)
                talkableCharacter.DialogueNum = 2;
        }
    }

    public override void RotateQuestClear(int dialogueNum)
    {
        base.RotateQuestClear(dialogueNum);
        Debug.Log("rotateQuestClear");
        QuestClear = true;
        checkNextQuest.talkableCharacter.DialogueNum = 1;

        talkableCharacter.DialogueNum = dialogueNum;
        talkableCharacter.dialogueUI.ChangeDialoguePos(dialogueStyle);
        StartQuest();
    }
}
