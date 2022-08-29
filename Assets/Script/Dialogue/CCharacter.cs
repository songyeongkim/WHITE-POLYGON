using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class CCharacter : CComponent
{
    [SerializeField]
    private string CharacterEventName;

    public delegate void CharacterClickEvent();
    public CharacterClickEvent characterClickEvent;
    public CQuestComponent nextEventApplyQuest;

    public bool autoNextDialogue = false;

    protected bool nowPlayEvent = false;

    [SerializeField]
    private int dialogueNum = 0;
    public int DialogueNum
    {
        set
        {
            dialogueNum = value;
            CQuestSystem.Instance.UpdateCharacterInfo(this);
        }
        get
        {
            return dialogueNum;
        }
    }

    public CDialogueObj dialogueUI;

    public CQuestComponent questComponent;

    [SerializeField]
    protected TextData[] dialogue;

    [Header("Play End Event if this true")]
    public bool autoQuestEnd = false;



    public override void Start()
    {
        CQuestSystem.Instance.SetCharacterInfo(this);
    }

    public virtual void NextEvent()
    {
        nowPlayEvent = false;
        int nextDialogue = DialogueNum;
        nextDialogue++;
        DialogueNum = nextDialogue;

        if (DialogueNum >= dialogue.Length)
        {
            questComponent.EndQuest();
        }
        else
        {
            questComponent.EndDialogue();
        }
    }

    public virtual void NextEvent(CQuestComponent cQuest)
    {
        nowPlayEvent = false;

        int nextDialogue = DialogueNum;
        nextDialogue++;
        DialogueNum = nextDialogue;

        if (DialogueNum >= dialogue.Length)
        {
            cQuest.EndQuest();
        }
        else
        {
            cQuest.EndDialogue();
        }
    }

    public void ShowDialogue()
    {
        CDialogueSystem cDialogue = CDialogueSystem.Instance;
        cDialogue.dialogueUI = dialogueUI;

        cDialogue.SetDialogueInfo(this, dialogueUI.textMesh, 0.1f, dialogue[DialogueNum]);
        cDialogue.WriteText();
    }
}
