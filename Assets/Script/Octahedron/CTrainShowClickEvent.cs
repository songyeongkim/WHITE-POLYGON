using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrainShowClickEvent : QClickEvent
{
    [Header("CTrainShowClickEvent")]
    [SerializeField]
    private GameObject trainTo7;

    public override void Start()
    {
        base.Start();
        EndQuestAdd += EndTrainShow;
    }

    public override void SetActiveState()
    {
        if(QuestClear)
        {
            trainTo7.SetActive(true);
        }  
    }

    public void EndTrainShow()
    {
        playSoundEvent.PlayMysteriousClearSoundEffect();
        trainTo7.SetActive(true);
    }
}
