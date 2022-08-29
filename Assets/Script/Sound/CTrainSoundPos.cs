using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CTrainSoundPos : CComponent, IStopSoundOnDestroy
{
    [Header("TrainMove Sound")]
    [SerializeField]
    private FMODUnity.StudioEventEmitter trainMoveSound;

    public static CTrainSoundPos instance;
    public CTrainMove movingTrain;

    public override void Awake()
    {
        instance = this;
    }

    private void OnDestroy()
    {
        StopSound();
    }

    public override void Update()
    {
        if(movingTrain != null && movingTrain.nowMove)
        {
            gameObject.transform.position = movingTrain.gameObject.transform.position;
        }
        else if(movingTrain != null && !movingTrain.nowMove)
        {
            StopSound();
        }
    }

    public void PlaySound()
    {
        trainMoveSound.Play();
    }
    public void StopSound()
    {
        trainMoveSound.Stop();
    }
}
