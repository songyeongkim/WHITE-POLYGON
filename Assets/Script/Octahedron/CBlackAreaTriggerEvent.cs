using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlackAreaTriggerEvent : QTriggerEvent
{
    [SerializeField]
    private CTrainMove train;

    [SerializeField]
    private float targetSpeed;

    public override void Start()
    {
        StartQuestAdd += TrainSpeedUp;
    }

    public void TrainSpeedUp()
    {
        train.moveSpeed = targetSpeed;
    }
}
