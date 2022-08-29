using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CUIManager : CSingleton<CUIManager>
{
    public bool uiCanInteract;

    public CTransformChange transformChange;
    public CCameraMove cameraMove;

    public GameObject itemNameTag;
    public TextMeshProUGUI itemNameTagText;

    private Texture2D cursorImg;
    private Texture2D pointerCursorImg;

    public override void Awake()
    {
        base.Awake();
    }

    public void ShowItemName(string a_Name)
    {
        itemNameTag.SetActive(true);
        itemNameTagText.text = a_Name;
    }

    public void HideItemName()
    {
        itemNameTag.SetActive(false);
    }

    public bool CheckIfUICanInteract()
    {
        if (uiCanInteract && transformChange == null && cameraMove == null)
        {
            return true;
        }
        else
        {
            ApplyNormalCursor();
            return false;
        }  
    }

    public void SetCursorImg(Texture2D a_Cursor, Texture2D a_PointerCursor)
    {
        cursorImg = a_Cursor;
        pointerCursorImg = a_PointerCursor;
    }


    public void ApplyNormalCursor()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void ApplyPointerCursorImg()
    {
        Cursor.SetCursor(pointerCursorImg, Vector2.zero, CursorMode.ForceSoftware);
    }
}
