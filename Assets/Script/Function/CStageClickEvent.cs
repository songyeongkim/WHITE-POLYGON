using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStageClickEvent : QClickEvent
{
    [Header("StageChangeOption")]
    [SerializeField]
    private CStageChange stageChange;

    public override void Start()
    {
        base.Start();
        StartQuestAdd += stageChange.SceneChangeEffect;
    }

    public override void ClickSoundPlay()
    {

    }
}
