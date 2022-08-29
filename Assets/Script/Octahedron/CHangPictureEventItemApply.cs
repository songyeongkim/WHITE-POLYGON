using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHangPictureEventItemApply : QItemApplyEvent
{
    [SerializeField]
    private GameObject fakeMonaLisa;
    [SerializeField]
    private GameObject museumKeeper_6;
    [SerializeField]
    private GameObject train_4_to_7;
    [SerializeField]
    private GameObject badPerson;

    public override void CheckQuestNum()
    {
        if(talkableCharacter.DialogueNum == 0)
        {
            base.CheckQuestNum();

            talkableCharacter.DialogueNum++;
            checkNextQuest.talkableCharacter.DialogueNum++;
            checkNextQuest.talkableCharacter.autoQuestEnd = true;

            SetActiveState();
        }
    }

    public override void SetActiveState()
    {
        if(talkableCharacter.DialogueNum == 1)
        {
            fakeMonaLisa.SetActive(true);
            museumKeeper_6.SetActive(true);
            badPerson.SetActive(true);
        }
    }

    public override void ItemApplySoundPlay()
    {
        playSoundEvent.PlayItemApplySoundEffect();
    }
}
