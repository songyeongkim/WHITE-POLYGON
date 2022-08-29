using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CWindowRotationState : CRotationStateCheck
{
    [SerializeField]
    private Transform UpPos;
    [SerializeField]
    private Transform DownPos;
    [SerializeField]
    private Transform RightPos;
    [SerializeField]
    private Transform LeftPos;

    public bool CheckRotationIsSetted()
    {
        if (UpDownPosCheck() && RightPos.position.x > LeftPos.position.x)
            return true;
        else
            return false;
    }

    public bool CheckHorizontalReverse()
    {
        if (UpDownPosCheck() && RightPos.position.x < LeftPos.position.x)
            return true;
        else
            return false;
    }

    public bool UpDownPosCheck()
    {
        if (UpPos.position.y > DownPos.position.y)
            return true;
        else
            return false;
    }
}
