using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKnightRotationEvent : QRotationEvent
{
    [Header("KnightRotationEvent")]
    [SerializeField]
    private Animator knightAnim;

    public override void Start()
    {
        base.Start();
    }

    public override void UpdateObserver(CCube cube)
    {
        if (windowRotationStateCheck.FrontWallCheck() && windowRotationStateCheck.CheckRotationIsSetted()
            && cubeRotationStateCheck.FrontWallCheck())
        {
            rotationMatched = true;
            checkNextQuest.QuestStart = true;

            if(talkableCharacter.DialogueNum != 5)
            {
                if (!QuestClear)
                {
                    RotateQuestClear(1);
                }
                else
                {
                    talkableCharacter.DialogueNum = 2;
                    knightAnim.SetBool("Idle", false);
                    knightAnim.SetBool("AttackStart", true);
                } 
            }
            
        }
        else
        {
            rotationMatched = false;
            checkNextQuest.QuestStart = false;

            if (QuestClear && talkableCharacter.DialogueNum != 5)
            {
                talkableCharacter.DialogueNum = 3;
                knightAnim.SetBool("AttackStart", false);
                knightAnim.SetBool("Idle", true);
            }
            else if(QuestClear && talkableCharacter.DialogueNum == 5)
            {
                knightAnim.SetBool("AttackStart", false);
                knightAnim.SetBool("Idle", false);
                knightAnim.SetBool("Victory", true);
            }
        }
    }

    public override void RotateQuestClear(int dialogueNum)
    {
        base.RotateQuestClear(dialogueNum);
        Debug.Log("rotateQuestClear");
        QuestClear = true;

        knightAnim.SetBool("Idle", false);
        knightAnim.SetBool("AttackStart", true);
        
        talkableCharacter.DialogueNum = dialogueNum;
        talkableCharacter.dialogueUI.ChangeDialoguePos(dialogueStyle);
        StartQuest();
    }
}
