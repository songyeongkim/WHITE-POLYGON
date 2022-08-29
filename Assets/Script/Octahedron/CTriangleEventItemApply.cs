using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTriangleEventItemApply : QItemApplyEvent
{
    [SerializeField]
    private GameObject noItemPlace;
    [SerializeField]
    private GameObject[] triangles;

    [SerializeField]
    private int targetRotateState;

    [SerializeField]
    private CTrainMove targetTrain;

    [SerializeField]
    private GameObject a_prismBottom;

    public override void Start()
    {
        base.Start();
        StartQuestAdd += TriangleApply;
    }

    public override void SetActiveState()
    {
        CPrismBottom prismBottom;

        if (CInventory.Instance.FindItem(a_prismBottom) != null)
        {
            prismBottom = CInventory.Instance.FindItem(a_prismBottom).GetComponent<CPrismBottom>();

            if (QuestClear && prismBottom.rotationState == targetRotateState)
            {
                triangles[targetRotateState].gameObject.SetActive(true);
                targetTrain.DestinationChange = true;
                targetTrain.autoMoveAfterRotate = true;
                noItemPlace.SetActive(false);

                CInventory.Instance.RemoveItem(prismBottom);
            }
            else if (QuestClear && prismBottom.rotationState != targetRotateState)
            {
                QuestClear = false;
                triangles[prismBottom.rotationState].gameObject.SetActive(true);
                noItemPlace.SetActive(false);
            }
        }
        else if(QuestClear)
        {
            triangles[targetRotateState].gameObject.SetActive(true);
            targetTrain.DestinationChange = true;
            targetTrain.autoMoveAfterRotate = true;
            noItemPlace.SetActive(false);
        }
        
    }

    public void TriangleApply()
    {
        if(dragState.item.gameObject.GetComponent<CPrismBottom>() != null)
        {
            CPrismBottom prismBottom = (CPrismBottom)dragState.item;

            if(prismBottom.rotationState == targetRotateState)
            {
                targetTrain.DestinationChange = true;
                targetTrain.autoMoveAfterRotate = true;

                for(int i = 0;i<triangles.Length;i++)
                {
                    triangles[i].GetComponent<CTriangleEventItemApply>().QuestClear = true;
                }

                CInventory.Instance.RemoveItem(dragState.item);
            }

            triangles[prismBottom.rotationState].gameObject.SetActive(true);

            noItemPlace.SetActive(false);
        }
    }
}
