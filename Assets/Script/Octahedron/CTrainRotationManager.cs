using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTrainRotationManager : CComponent
{
    //현재 이어진 길이 무엇인지
    public bool[] ActiveRoadNum;

    //출발할 기차 후보
    [SerializeField]
    private CTrainMove[] trains;

    [SerializeField]
    private CTrainMove firstTrain;

    //기차를 출발시키는 버튼
    [SerializeField]
    private CStarRoadDirButton roadChangeButton;

    private int activeTrain = 3;
    private int destRoad;

    //기차와 목적지 세팅하는 함수. 배경 회전이 끝났을 때 실행된다.
    public void SettedTrain()
    {
        bool trainActive = false;

        for(int i=0;i< ActiveRoadNum.Length;i++)
        {
            //현재 이어진 길에 활성화된 기차가 있는지 검사

            //최초 기차가 활성화되어 있을 경우 0번이 이어졌다면 트루
            if(firstTrain.isActiveAndEnabled && ActiveRoadNum[0])
            {
                roadChangeButton.Train = firstTrain;
                roadChangeButton.trainCanMove = true;

                if(i != 0 && ActiveRoadNum[i])
                {
                    destRoad = i;
                    roadChangeButton.SetDestPos(destRoad);
                }
            }
            else if(trains[i].isActiveAndEnabled && ActiveRoadNum[i])
            {
                activeTrain = i;
                roadChangeButton.Train = trains[i];

                //있다면 기차 출발 버튼 활성화
                trainActive = true;
                roadChangeButton.trainCanMove = true;
                
            }
            else if (ActiveRoadNum[i])
            {
                //기차가 활성화되지 않은 길은 자동으로 목적지가 된다.
                destRoad = i;
                roadChangeButton.SetDestPos(destRoad);
            }
        }

        if (!trainActive)
            activeTrain = 3;

        //Debug.Log("train : " + activeTrain + ", dest : " + destRoad);
        ChangeRotateAngle();
    }

    //stopPos에 기차가 멈췄을 때 회전할 각도 세팅
    public void ChangeRotateAngle()
    {
        if((activeTrain - destRoad) == -1 || (activeTrain - destRoad) == 2 ||
            (firstTrain.isActiveAndEnabled && destRoad == 1))
        {
            roadChangeButton.RotateAngle = -60;
        }

        if ((activeTrain - destRoad) == 1 || (activeTrain - destRoad) == -2 ||
            (firstTrain.isActiveAndEnabled && destRoad == 2))
        {
            roadChangeButton.RotateAngle = 60;
        }
    }

    //어떤 길이 활성화 되어 있는지 정보 받아오기
    public void ResetActiveRoad()
    {
         for(int i=0;i<ActiveRoadNum.Length;i++)
        {
            ActiveRoadNum[i] = false;
        }
    }

    public void BottomRightActive()
    {
        ResetActiveRoad();
        ActiveRoadNum[0] = true;
        ActiveRoadNum[2] = true;
        SettedTrain();
    }

    public void BottomLeftActive()
    {
        ResetActiveRoad();
        ActiveRoadNum[0] = true;
        ActiveRoadNum[1] = true;
        SettedTrain();
    }

    public void LeftRightActive()
    {
        ResetActiveRoad();
        ActiveRoadNum[1] = true;
        ActiveRoadNum[2] = true;
        SettedTrain();
    }

    public void BottomActive()
    {
        ResetActiveRoad();
    }
}
