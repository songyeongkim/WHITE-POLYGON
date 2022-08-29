using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CStartTalkEvent : QStartQuest
{
    [SerializeField]
    private bool bgmStart = false;
    [SerializeField]
    private FMODUnity.StudioEventEmitter bgm;

    public override void Start()
    {
        base.Start();
        EndQuestAdd += BGMStart;
    }

    private void BGMStart()
    {
        if(bgmStart)
        {
            playSoundEvent.ChangeBgm(bgm);
            playSoundEvent.PlayBGM();
        }
            
    }
}
