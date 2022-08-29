using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CReverseRoadChangeButton : CRoadChangeButton
{
    [SerializeField]
    private CStarRoadDirButton starRoadButton;

    [SerializeField]
    private CTrainRotationManager trainRotationManager;

    public override void Start()
    {
        base.Start();
        train.ReverseRoad = this;
    }

    public override void OnMouseDown()
    {
        Debug.Log("click");

        if (train.CanRotate)
        {
            //기차가 회전이 가능하면(멈춰 있으면) 회전시킴
            rotateStart = true;
            trainRotationManager.SettedTrain();
        }
    }

}
