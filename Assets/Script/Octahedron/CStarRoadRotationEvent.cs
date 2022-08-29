using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStarRoadRotationEvent : QRotationEvent
{
    [SerializeField]
    private CTrainMove[] matchedTrain;

    [SerializeField]
    private CTrainRotationManager trainRotationManager;

    [Header("ActiveRoadCheck")]
    [SerializeField]
    private int canActiveRoad;

    public override void Start()
    {
        base.Start();
        backWindowCube.SubscribeEvent(this);
    }

    public override void UpdateObserver(CCube cube)
    {
        if(windowRotationStateCheck.FrontWallCheck())
        {
            trainRotationManager.ResetActiveRoad();

            if (canActiveRoad == 3)
            {
                if (windowRotationStateCheck.CheckHorizontalReverse())
                {
                    trainRotationManager.BottomLeftActive();
                }
                else if (windowRotationStateCheck.CheckRotationIsSetted())
                {
                    trainRotationManager.BottomRightActive();
                }
            }
            else if (canActiveRoad == 2 && (windowRotationStateCheck.CheckRotationIsSetted() || windowRotationStateCheck.CheckHorizontalReverse()))
            {
                trainRotationManager.LeftRightActive();
            }
            else if(canActiveRoad == 1)
            {
                trainRotationManager.BottomActive();
            }
        }
    }

}
