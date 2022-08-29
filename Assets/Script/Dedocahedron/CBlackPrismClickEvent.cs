using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlackPrismClickEvent : QClickEvent
{
    [Header("BlackPrismEvent")]
    [SerializeField]
    private Animator titleAnim;

    public override void Start()
    {
        base.Start();
        StartQuestAdd += TitleShow;
    }

    private void TitleShow()
    {
        playSoundEvent.PlayStageChangeSoundEffect();

        QuestClear = true;
        titleAnim.gameObject.SetActive(true);
        titleAnim.SetBool("show", true);
    }  
}
