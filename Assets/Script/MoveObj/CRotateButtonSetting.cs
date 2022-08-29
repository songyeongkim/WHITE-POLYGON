using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRotateButtonSetting : CComponent
{
    [SerializeField]
    private CRotatableObj rotatableObj;

    public void RightButton()
    {
        if(CUIManager.Instance.uiCanInteract)
        {
            rotatableObj.RotateRightButtonClick();
        }
    }

    public void LeftButton()
    {
        if (CUIManager.Instance.uiCanInteract)
        {
            rotatableObj.RotateLeftButtonClick();
        }
    }

    public void UpButton()
    {
        if (CUIManager.Instance.uiCanInteract)
        {
            rotatableObj.RotateUpButtonClick();
        }
    }

    public void DownButton()
    {
        if (CUIManager.Instance.uiCanInteract)
        {
            rotatableObj.RotateDownButtonClick();
        }
    }
}
