using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OctahedronStateInfo
{
    //현재 있는 면
    public int wallNum;
    public Vector3 cameraTargetMovePos;
    public Vector3 playerPos;
    public bool playerCamOn = false;


    public void OctahedronSetting(int a_WallNum, Vector3 a_CameraTargetMovePos, Vector3 a_PlayerPos, bool a_PlayerCamOn)
    {
        cameraTargetMovePos = a_CameraTargetMovePos;
        playerPos = a_PlayerPos;
        playerCamOn = a_PlayerCamOn;
        wallNum = a_WallNum;
    }

    public void OctahedronSetting(OctahedronStateInfo a_OctahedronStateInfo)
    {
        cameraTargetMovePos = a_OctahedronStateInfo.cameraTargetMovePos;
        playerPos = a_OctahedronStateInfo.playerPos;
        playerCamOn = a_OctahedronStateInfo.playerCamOn;
        wallNum = a_OctahedronStateInfo.wallNum;
    }
}

public class COctahedron : CRotatableObj
{
    [Header("OctahedronSetting")]
    public int cameraState;

    [SerializeField]
    private Transform[] cameraPoses;

    [SerializeField]
    private CTrainMove[] trainActivate;

    [SerializeField]
    private CRotateButton[] rotateButtons;

    [SerializeField]
    private GameObject triangleEventClear;

    [SerializeField]
    private Camera MainCamera;

    [SerializeField]
    private float cameraMoveSpeed;

    private CCameraMove cameraMove;

    [Header("TrainSetting")]
    [SerializeField]
    private GameObject train_0;
    [SerializeField]
    private GameObject train_3;

    [Header("PlayerPosSetting")]
    [SerializeField]
    private Player player;
    [SerializeField]
    private CForestShow forestShow;

    [Header("StageManager")]
    [SerializeField]
    private CStageManager stageManager;

    public override void Start()
    {
        base.Start();
        rotationInit = MainCamera.gameObject.transform;
        CUIManager.Instance.uiCanInteract = true;
        stageManager = CStageManager.Instance;

        int wallNum = stageManager.octahedronStateInfo.wallNum;

        if(wallNum >= 2 && wallNum < 4 && !triangleEventClear.activeSelf)
        {
            TrainActivateSetting(1);
        }
        else
        {
            TrainActivateSetting(wallNum);
        }

        if(wallNum == 4 || wallNum == 7)
        {
            forestShow.StageChangeIntoForest();
            player.gameObject.SetActive(true);
        }
        else
        {
            rotateButtons[wallNum].RotateStateSetting();
        }

        if (wallNum == 5 || wallNum == 6)
        {
            trainActivate[4].gameObject.SetActive(false);
        }
    }

    private void TrainActivateSetting(int a_wallNum)
    {
        trainActivate[a_wallNum].gameObject.SetActive(true);
    }

    //면 이동 카메라 처리
    public void RotateCamera(int a_targetPos)
    {
        if (!rotateStart)
        {
            cameraState = a_targetPos;
            cameraMove = gameObject.GetComponent<CCameraMove>();
            cameraMove.SetCameraMove(MainCamera, cameraPoses[a_targetPos], cameraMoveSpeed);
            cameraMove.MoveStart();

            stageManager.octahedronStateInfo.wallNum = a_targetPos;
            stageManager.octahedronStateInfo.playerPos = player.transform.position;
        }
    }

}
