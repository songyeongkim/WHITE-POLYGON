using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDedoTriggerEvent : QTriggerEvent
{
    [Header("StageChangeOption")]
    [SerializeField]
    private CStageChange stageChange;

    public override void Start()
    {
        StartQuestAdd += stageChange.SceneChangeEffect;
    }
}
