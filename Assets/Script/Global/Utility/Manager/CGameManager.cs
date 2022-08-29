using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : CComponent
{
    [SerializeField]
    Texture2D cursorImg;

    [SerializeField]
    Texture2D pointerCursorImg;

    CUIManager uIManager;
    CDialogueSystem dialogueSystem;
    CInventory inventory;
    CQuestSystem questSystem;
    //BlackInOut blackInOut;
    CTradeSlotInfo tradeSlotInfo;
    CStageManager stageManager;
    CDragState dragState;

    public override void Awake()
    {
        uIManager = CUIManager.Instance;
        dialogueSystem = CDialogueSystem.Instance;
        inventory = CInventory.Instance;
        questSystem = CQuestSystem.Instance;
        tradeSlotInfo = CTradeSlotInfo.Instance;
        stageManager = CStageManager.Instance;
        dragState = CDragState.Instance;
    }

    public override void Start()
    {
        if (cursorImg != null && pointerCursorImg != null)
            uIManager.SetCursorImg(cursorImg, pointerCursorImg);
    }

    public void ApplyNormalCursor()
    {
        uIManager.ApplyNormalCursor();
    }

    public void ApplyPointerCursorImg()
    {
        uIManager.ApplyPointerCursorImg();
    }


}
