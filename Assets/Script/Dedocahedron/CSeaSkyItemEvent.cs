using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSeaSkyItemEvent : QItemEvent
{
    [Header("SeaSkyEvent")]
    [SerializeField]
    private CCameraMove skyCameraMove;

    [SerializeField]
    private GameObject nowShowingCamera;

    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject whitePolygon;
    [SerializeField]
    private GameObject blackPolygon;

    public override void Start()
    {
        base.Start();
        EndQuestAdd += SeaSky;
    }

    public void SeaSky()
    {
        player.canMove = false;
        whitePolygon.SetActive(false);
        blackPolygon.SetActive(true);

        nowShowingCamera.transform.parent = skyCameraMove.transform;
        //skyCameraMove.endTransformEvent += ChangeCameraEdgeColor;
        ChangeCameraEdgeColor();
        skyCameraMove.MoveStart();
    }

    public void ChangeCameraEdgeColor()
    {
        skyCameraMove.changeObj.gameObject.GetComponent<EdgeDetect>().outlineColor = Color.white;
    }
}

