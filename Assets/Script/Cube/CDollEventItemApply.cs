using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDollEventItemApply : QItemApplyEvent
{
    [Header("Quest Clear Item")]
    [SerializeField]
    private CGettableObj[] giveItem;

    [SerializeField]
    private GameObject dollNose;
    [SerializeField]
    private GameObject dollDirty;
    [SerializeField]
    private GameObject boxChair;
    [SerializeField]
    private RectTransform dollPos;

    //퀘스트 완료 후 획득할 아이템
    [SerializeField]
    private CGettableObj currentGiveItem;

    [SerializeField]
    private GameObject noCottonDoll;
    [SerializeField]
    private GameObject cottonDoll;

    public override void Start()
    {
        base.Start();
        StartQuestAdd += NoseShow;
        EndDialogueAdd += GetItem;
        EndQuestAdd += GetItem;
    }

    public override void SetActiveState()
    {
        if (checkNextQuest.talkableCharacter.DialogueNum == 1)
        {
            cottonDoll.SetActive(false);
            noCottonDoll.SetActive(true);
        }  
        else if (checkNextQuest.talkableCharacter.DialogueNum == 2)
        {
            dollDirty.SetActive(false);
            cottonDoll.SetActive(false);
            noCottonDoll.SetActive(true);
            SetFalseBoxChair();
        }

        if(CStageManager.Instance.octahedron)
        {
            dollDirty.SetActive(false);
            cottonDoll.SetActive(false);
            noCottonDoll.SetActive(false);
            SetFalseBoxChair();
        }
    }

    public void NoseShow()
    {
        if (checkNextQuest.talkableCharacter.DialogueNum == 0)
            dollNose.SetActive(true);
        if (checkNextQuest.talkableCharacter.DialogueNum == 1)
            dollDirty.SetActive(false);
    }

    public void GetItem()
    {
        Debug.Log("giveItem");
        checkNextQuest.talkableCharacter.DialogueNum++;
        currentGiveItem.AddItemEvent();

        if(currentNeedItem == needItem[0])
        {
            int newNum = talkableCharacter.DialogueNum;
            newNum++;
            talkableCharacter.DialogueNum = newNum;

            currentNeedItem = needItem[1];
            currentGiveItem = giveItem[1];

            cottonDoll.SetActive(false);
            noCottonDoll.SetActive(true);
        }
        else
        {
            SetFalseBoxChair();
        }
    }

    public void SetFalseBoxChair()
    {
        boxChair.SetActive(false);
        //여기 콜라이더 위치 잘 맞춰줄 방법 찾기
        dollPos.anchoredPosition = new Vector2(dollPos.anchoredPosition.x, -25);
    }

    public override void ItemApplyEvent()
    {
        if(checkNextQuest.talkableCharacter.DialogueNum == 1)
        {
            currentNeedItem = needItem[1];
            currentGiveItem = giveItem[1];
        }
        else
        {
            currentNeedItem = needItem[0];
            currentGiveItem = giveItem[0];
        }

        if (dragState.item == currentNeedItem)
        {
            ItemApplySoundPlay();
            Debug.Log("ItemApply");
            CInventory.Instance.RemoveItem(dragState.item);
            StartQuest();
        }
    }
}
