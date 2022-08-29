using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum DIALOGUESTYLE { UP_LEFT, UP_RIGHT, UP_MIDDLE, DOWN_LEFT, DOWN_RIGHT, DOWN_MIDDLE, OBJCENTER };


public class CDialogueObj : CComponent
{
    [SerializeField]
    private RectTransform dialoguePos;

    public TextMeshProUGUI textMesh;


    public override void Start()
    {
        CDialogueSystem.Instance.dialogueUI = this;
    }

    private void OnEnable()
    {
        CUIManager.Instance.uiCanInteract = false;
    }

    private void OnDisable()
    {
        CUIManager.Instance.uiCanInteract = true;
    }

    public void ChangeDialoguePos(DIALOGUESTYLE dialogueStyle)
    {
        Vector2 pos;

        switch(dialogueStyle)
        {
            case DIALOGUESTYLE.UP_LEFT:
                pos = new Vector2(-505, -180);
                break;
            case DIALOGUESTYLE.UP_RIGHT:
                pos = new Vector2(505, -180);
                break;
            case DIALOGUESTYLE.UP_MIDDLE:
                pos = new Vector2(0, -180);
                break;
            case DIALOGUESTYLE.DOWN_LEFT:
                pos = new Vector2(-505, -950);
                break;
            case DIALOGUESTYLE.DOWN_RIGHT:
                pos = new Vector2(505, -950);
                break;
            case DIALOGUESTYLE.DOWN_MIDDLE:
                pos = new Vector2(0, -950);
                break;
            case DIALOGUESTYLE.OBJCENTER:
                pos = new Vector2(0, -388);
                break;
            default:
                pos = new Vector2(0, -388);
                break;
        }

        dialoguePos.anchoredPosition = pos;
    }
}
