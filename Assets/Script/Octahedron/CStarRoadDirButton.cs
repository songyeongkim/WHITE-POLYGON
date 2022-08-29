using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStarRoadDirButton : CRoadChangeButton
{
    [Header("StarRoadSetting")]
    public Transform settedDestPos;
    public CTrainMove settedNextTrain;
    public bool trainCanMove = false;

    [SerializeField]
    private Transform[] destPoses;
    [SerializeField]
    private CTrainMove[] nextTrains;
    [SerializeField]
    private CReverseRoadChangeButton[] reverseRoads;

    public void SetRotationEnds()
    {
        for(int i=0;i<reverseRoads.Length;i++)
        {
            reverseRoads[i].rotateEnd = false;
        }
    }

    public void SetDestPos(int a_DestNum)
    {
        //목적지 설정
        settedDestPos = destPoses[a_DestNum];
        //목적지에 최종으로 들어올 기차가 어느 기차인지 설정
        settedNextTrain = nextTrains[a_DestNum];

        Debug.Log(train.nextTrain);

        //중간 회전하는 기차에 대해 목적지와 다음 기차 할당
        train.nextTrain.nextTrain = settedNextTrain;
        train.nextTrain.DestPos = settedDestPos;

        Debug.Log(train.nextTrain);
    }

    //클릭시 세팅된 기차 출발
    public override void OnMouseDown()
    {
        Debug.Log("click");
        if (trainCanMove)
        {
            //기차 목적지 변환 설정
            train.DestinationChange = true;

            //기차 실질적 움직임 시작
            train.nowMove = true;

            //출발 버튼 비활성화
            trainCanMove = false;
        } 
    }
}
