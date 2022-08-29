using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDragonEventItemApply : QItemApplyEvent
{
    [Header("Quest Picture Change")]
    [SerializeField]
    private Material[] materials;
    [SerializeField]
    private GameObject matApplyObj;
    private Renderer rend;

    [Header("Quest Clear Item")]
    [SerializeField]
    private CGettableObj giveItem;

    [SerializeField]
    private Animator knightAnim;

    public override void Start()
    {
        base.Start();
        EndDialogueAdd += GetItem;

        rend = matApplyObj.GetComponent<Renderer>();
    }

    public override void CheckQuestNum()
    {
        if (talkableCharacter.DialogueNum < 4 && rotationState.rotationMatched)
        {
            talkableCharacter.DialogueNum = 4;
            talkableCharacter.nextEventApplyQuest = this;
            talkableCharacter.dialogueUI.ChangeDialoguePos(dialogueStyle);
            talkableCharacter.ShowDialogue();

            rend.material = materials[0];
        }   
    }

    public void GetItem()
    {
        Debug.Log("giveItem");
        checkNextQuest.talkableCharacter.DialogueNum = 5;
        rotationState.QuestClear = true;

        talkableCharacter.nextEventApplyQuest = null;
        giveItem.AddItemEvent();

        knightAnim.SetBool("Victory", true);
        knightAnim.SetBool("Idle", false);
        knightAnim.SetBool("AttackStart", false);

        rend.material = materials[1];
    }
}
