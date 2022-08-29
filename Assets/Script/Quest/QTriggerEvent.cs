using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTriggerEvent : CQuestComponent
{
    [Header("PlayerTag")]
    [SerializeField]
    private string playerTag;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == playerTag)
        {
            StartQuest();
        }
    }
}
