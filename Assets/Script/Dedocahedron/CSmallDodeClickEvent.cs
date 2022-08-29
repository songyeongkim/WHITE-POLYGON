using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSmallDodeClickEvent : QClickEvent
{
    [Header("DodeClickEvent")]
    [SerializeField]
    private CTransformChange bigCharacter;

    [SerializeField]
    private GameObject bigMoveChangeShow;

    [SerializeField]
    private CTransformChange leftArmMove;
    [SerializeField]
    private CTransformChange rightArmMove;
    [SerializeField]
    private CCameraMove cameraMoveToBack;

    [SerializeField]
    private GameObject hideTile;
    [SerializeField]
    private GameObject showBackScene;
    [SerializeField]
    private GameObject hideBlackArea;
    [SerializeField]
    private GameObject hideInventory;



    public override void CheckQuestNum()
    {
        playSoundEvent.PlayMysteriousChangeSoundEffect();

        hideTile.SetActive(false);
        bigMoveChangeShow.SetActive(true);
        bigCharacter.endTransformEvent += ArmsMove;
        bigCharacter.MoveStart();
    }

    private void ArmsMove()
    {
        leftArmMove.endTransformEvent += CameraMoveBack;
        leftArmMove.MoveStart();
        rightArmMove.MoveStart();
    }

    private void CameraMoveBack()
    {
        hideBlackArea.SetActive(false);
        hideInventory.SetActive(false);

        cameraMoveToBack.endTransformEvent += ShowTitleCamera;
        cameraMoveToBack.MoveStart();
    }

    private void ShowTitleCamera()
    {
        checkNextQuest.QuestStart = true;
    }
}
