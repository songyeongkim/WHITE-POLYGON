using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRotateCameraHide : QRotationEvent
{
    [SerializeField]
    private GameObject[] cameras;

    [SerializeField]
    private int showWallNum;

    public override void Start()
    {
        innerRoomCube.SubscribeEvent(this);
    }

    public override void UpdateObserver(CCube cube)
    {
        showWallNum = (int)innerRoomCube.wallNBottomNowState.x;

        for (int i=0;i<cameras.Length;i++)
        {
            if (cameras[i] != null)
                cameras[i].SetActive(false);
        }
        if (cameras[showWallNum] != null)
            cameras[showWallNum].SetActive(true);
    }
}
