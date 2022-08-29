using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRotationStateCheck : CComponent
{
    [SerializeField]
    private Transform frontWall;

    [SerializeField]
    private Transform[] rotationWallPos;

    private Vector3 initFrontWall;

    public override void Start()
    {
        initFrontWall = frontWall.position;
    }

    public bool CheckThisWallIsFront(Transform a_targetTransform)
    {
        if (a_targetTransform.position == initFrontWall)
        {
            return true;
        }
        else
            return false;
    }

    public bool FrontWallCheck()
    {
        for(int i=0;i<rotationWallPos.Length;i++)
        {
            if(CheckThisWallIsFront(rotationWallPos[i]))
            {
                return true;
            }
        }
        return false;
    }


    public bool CheckVectorInArray(Vector2[] vectors, Vector2 vector)
    {
        for (int i = 0; i < vectors.Length; i++)
        {
            if (vector == vectors[i])
                return true;
        }
        return false;
    }


}
