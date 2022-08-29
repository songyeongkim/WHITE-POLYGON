using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRotationEvent : CQuestComponent, IRotateObserver
{
    [Header("Rotate State Check")]
    [SerializeField]
    protected CWindowRotationState windowRotationStateCheck;

    [SerializeField]
    protected CInnerRotationState cubeRotationStateCheck;

    [SerializeField]
    protected QItemApplyEvent eventItemApply;

    public bool rotationMatched;


    [Header("Rotate End Observer")]
    [SerializeField]
    protected CCube innerRoomCube;
    [SerializeField]
    protected CCube backWindowCube;

    public override void Start()
    {
        base.Start();

        if(innerRoomCube != null)
            innerRoomCube.SubscribeEvent(this);

        backWindowCube.SubscribeEvent(this);
    }

    public virtual void UpdateObserver(CCube cube)
    {

    }

}
