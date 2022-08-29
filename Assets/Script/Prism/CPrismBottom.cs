using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPrismBottom : CItem
{
    public int rotationState;
    public int RotationState
    {
        set
        {
            rotationState = value;
            itemImg = rotationImgs[rotationState];
        }
    }

    [SerializeField]
    private Image[] rotationImgs;
}
