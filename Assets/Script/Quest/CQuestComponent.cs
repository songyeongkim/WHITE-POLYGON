using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CQuestComponent : CComponent, IQuestEvent, IStartActiveInfo
{
    public delegate void QuestAdd();
    public QuestAdd StartQuestAdd;
    public QuestAdd EndQuestAdd;
    public QuestAdd EndDialogueAdd;

    [SerializeField]
    private bool questStart = false;
    public bool QuestStart
    {
        set
        {
            questStart = value;
            CQuestSystem.Instance.UpdateQuestComponentInfo(this);
        }
        get
        {
            return questStart;
        }
    }
    [SerializeField]
    private bool questClear = false;
    public bool QuestClear
    {
        set
        {
            questClear = value;
            CQuestSystem.Instance.UpdateQuestComponentInfo(this);
        }
        get
        {
            return questClear;
        }
    }

    [Header("DialogueCharacter")]
    public CCharacter talkableCharacter;
    [Header("DialogueStyle")]
    public DIALOGUESTYLE dialogueStyle;

    public CQuestComponent checkPrevQuest;
    public CQuestComponent checkNextQuest;

    [Header("RotationStateCheck")]
    [SerializeField]
    protected QRotationEvent rotationState;

    [SerializeField]
    protected CPlaySoundEvent playSoundEvent;

    public override void Start()
    {
        playSoundEvent = CPlaySoundEvent.Instance;
        CQuestSystem.Instance.SetQuestComponentInfo(this);
        StartQuestAdd += CheckQuestNum;
    }

    public virtual void CheckQuestNum()
    {
        if(talkableCharacter != null)
        {
            talkableCharacter.dialogueUI.ChangeDialoguePos(dialogueStyle);
            talkableCharacter.ShowDialogue();
        }
    }

    public void StartQuest()
    {
        if (StartQuestAdd != null)
            StartQuestAdd();
    }

    public void EndQuest()
    {
        if (EndQuestAdd != null)
        {
            EndQuestAdd();
        }
        QuestClear = true;
        CheckNextState();
    }

    public void EndDialogue()
    {
        if (EndDialogueAdd != null)
        {
            EndDialogueAdd();
        }
    }

    public void DialogueStart()
    {
        talkableCharacter.ShowDialogue();
    }

    public void CheckPrevState()
    {
        if (checkPrevQuest.questClear)
            QuestStart = true;
    }

    public void CheckNextState()
    {
        if(checkNextQuest != null)
            checkNextQuest.QuestStart = true;
    }

    public virtual void RotateQuestClear(int dialogueNum)
    {
        playSoundEvent.PlayRotateClearSoundEffect();
        QuestClear = true;
    }

    public virtual void SetActiveState()
    {

    }
}
