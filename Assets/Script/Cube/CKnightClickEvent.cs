using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKnightClickEvent : QClickEvent
{
    [Header("KnightEvent")]
    [SerializeField]
    private Animator knightAnim;

    public override void Start()
    {
        base.Start();

        if (talkableCharacter.DialogueNum == 5)
        {
            knightAnim.SetBool("Idle", false);
            knightAnim.SetBool("Victory", true);
        }
    }
}
