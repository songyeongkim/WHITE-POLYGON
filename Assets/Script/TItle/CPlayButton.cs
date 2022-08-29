using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CPlayButton : QClickEvent
{
    [Header("ButtonInnerGraphic")]
    [SerializeField]
    private GameObject playShow;

    [SerializeField]
    private GameObject titlePrism;

    [Header("PrismClickEvent")]
    [SerializeField]
    private Animator hideTitle;
    [SerializeField]
    private CCameraMove cameraMove;


    public override void Start()
    {
        playSoundEvent = CPlaySoundEvent.Instance;
        CQuestSystem.Instance.SetQuestComponentInfo(this);

        CUIManager.Instance.uiCanInteract = true;

        cameraMove.endTransformEvent += StartGame;

        StartQuestAdd += CameraMove;
        EndQuestAdd += EnableOpenBox;
    }

    public void CameraMove()
    {
        hideTitle.SetBool("TitleHide", true);
        cameraMove.MoveStart();
        cameraMove.SetTargetCamerSize();
        StartQuestAdd -= CameraMove;
    }


    public void StartGame()
    {
        Debug.Log("start");
        Destroy(gameObject.GetComponent<BoxCollider>());
        cameraMove.endTransformEvent -= StartGame;

        CheckQuestNum();
    }

    private void EnableOpenBox()
    {
        talkableCharacter.questComponent = checkNextQuest;
        checkNextQuest.QuestStart = true;
    }

}
