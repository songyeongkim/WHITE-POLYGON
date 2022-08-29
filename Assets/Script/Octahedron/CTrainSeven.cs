using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrainSeven : QClickEvent, IStopSoundOnDestroy
{
    [Header("CTrainSeven")]
    [SerializeField]
    private CTrainMove trainMove;
    [SerializeField]
    private GameObject trainCam;
    [SerializeField]
    private GameObject defaultCam;
    [SerializeField]
    private GameObject endBlackPlace;

    public override void Start()
    {
        base.Start();
        StartQuestAdd += StopBGM;
        EndQuestAdd += StartMoveTrain;
    }

    private void StopBGM()
    {
        playSoundEvent.StopBGM();
    }

    private void StartMoveTrain()
    {
        trainMove.nowMove = true;
        trainCam.SetActive(true);
        defaultCam.SetActive(false);
        endBlackPlace.SetActive(true);
        playSoundEvent.ChangeBgm(playSoundEvent.lastTrain);
        playSoundEvent.PlayBGM();
    }

    public void StopSound()
    {
        playSoundEvent.StopBGM();
    }

    public void OnDestroy()
    {
        StopSound();
    }


}
