using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlackWallRotationEvent : QRotationEvent
{
    [SerializeField]
    private CStageClickEvent octahedronShow;

    [SerializeField]
    private GameObject doorWall;

    public override void UpdateObserver(CCube cube)
    {
        if (windowRotationStateCheck.FrontWallCheck() && windowRotationStateCheck.CheckRotationIsSetted()
            && cubeRotationStateCheck.FrontWallCheck() && QuestStart)
        {
            octahedronShow.gameObject.SetActive(true);
            octahedronShow.QuestStart = true;
            doorWall.layer = LayerMask.NameToLayer("wallNotWrite");
        }
        else
        {
            octahedronShow.gameObject.SetActive(false);
            octahedronShow.QuestStart = false;
            doorWall.layer = LayerMask.NameToLayer("Default");
        }
    }
}
