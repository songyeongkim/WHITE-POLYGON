using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPrismBottomItemEvent : QItemEvent
{
    public override void Start()
    {
        base.Start();
    }

    public override void SetActiveState()
    {
        if (QuestClear)
        {
            gettableObj.gettableItem = false;
        }
    }
}
