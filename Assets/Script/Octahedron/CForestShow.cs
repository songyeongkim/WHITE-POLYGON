using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CForestShow : QClickEvent
{
    private CTrainMove train;

    [Header("CameraMoves")]
    [SerializeField]
    private CTransformChange screenChange;
    [SerializeField]
    private CCameraMove cameraChange;

    [Header("ShowOrHideObjects")]
    [SerializeField]
    private bool showObj = false;
    [SerializeField]
    private GameObject backRotateButton;
    [SerializeField]
    private GameObject npc;
    [SerializeField]
    private Player player;
    [SerializeField]
    private GameObject[] cameraMoveButtons;
    [SerializeField]
    private GameObject defaultCam;

    [Header("KeySettingShow")]
    [SerializeField]
    private CKeySettingShow keyInfo;

    [Header("OtherForestCanShow")]
    public bool canInteract = true;
    [SerializeField]
    private CForestShow[] otherForestShowButton;

    [Header("StageManager")]
    [SerializeField]
    private bool a_PlayerCamOn = false;
    private CStageManager stageManager;


    public override void Start()
    {
        base.Start();

        train = gameObject.GetComponent<CTrainMove>();
        stageManager = CStageManager.Instance;

        StartQuestAdd += IntoForest;
        screenChange.endTransformEvent += PlayerMoveStart;
    }

    public override void SetActiveState()
    {
        if(QuestStart && !QuestClear)
        {
            canInteract = true;
        }
    }

    public void StageChangeIntoForest()
    {
        StartQuest();
        screenChange.endTransformEvent += PlayerMoveStart;
    }

    public void IntoForest()
    {
        if(canInteract)
        {
            canInteract = false;
            stageManager.octahedronStateInfo.playerCamOn = a_PlayerCamOn;

            for(int i=0;i<otherForestShowButton.Length;i++)
            {
                if (otherForestShowButton != null)
                    otherForestShowButton[i].canInteract = true;
            }

            if (train != null && !train.nowMove || train == null)
            {
                if(train != null)
                {
                    train.soundSetting = true;
                    train.MovingSoundPosSettting();
                }

                screenChange.MoveStart();
                cameraChange.MoveStart();

                if (keyInfo != null)
                {
                    keyInfo.gameObject.SetActive(true);
                    screenChange.endTransformEvent += KeySettingShow;
                }

                ShowOrHideObjs();
            }
        }
    }

    private void KeySettingShow()
    {
        keyInfo.animCanStart = true;
    }

    //장면이 바뀔 때 보일 오브젝트와 보이지 않을 오브젝트 구분
    public void ShowOrHideObjs()
    {
        backRotateButton.SetActive(!showObj);
        npc.SetActive(showObj);
        player.gameObject.SetActive(showObj);
        defaultCam.SetActive(!showObj);


        for (int i = 0; i < cameraMoveButtons.Length; i++)
        {
            cameraMoveButtons[i].SetActive(true);
        }
    }

    public void PlayerMoveStart()
    {
        cameraChange.endEvent();
        player.canMove = showObj;
    }
}
