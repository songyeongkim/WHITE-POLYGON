using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAutoChangeTrain : CComponent
{
    [SerializeField]
    private CStarRoadDirButton roadDirButton;

    public void ChangeTrain(CTrainMove a_TrainMove)
    {
        if(a_TrainMove.canNextTrain)
        {
            roadDirButton.Train = gameObject.GetComponent<CTrainMove>();
            roadDirButton.rotateEnd = false;
        }    
    }
}
