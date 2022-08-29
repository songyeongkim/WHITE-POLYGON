using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CItem : CComponent
{
    public Image itemImg;
    public string itemName;

    [SerializeField]
    private CItem requirementItem;

    public bool CheckRequirement(CItem a_RequirementItem)
    {
        if(a_RequirementItem == requirementItem)
        {
            return true;
        }

        return false;
    }
}
