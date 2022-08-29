using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QMonaRisaItemEvent : QItemEvent
{
    [Header("OctahedronDoor")]
    [SerializeField]
    protected GameObject door;

    public override void Start()
    {
        base.Start();
        EndQuestAdd += DoorEnable;
    }

    public override void SetActiveState()
    {
        if(QuestClear)
        {
            DoorEnable();
        }
    }

    private void DoorEnable()
    {
        door.SetActive(true);
        gameObject.SetActive(false);
    }
}
