using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CPenroseClickEvent : QClickEvent
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float power;

    [SerializeField]
    private CTransformChange transformChange;
    [SerializeField]
    private Player playerMoveScript;

    [SerializeField]
    private FMODUnity.StudioEventEmitter jumpSound;

    [SerializeField]
    private FMODUnity.StudioEventEmitter hitGroundSound;

    public override void Start()
    {
        base.Start();
        StartQuestAdd += JumpToTile;

        transformChange.endTransformEvent += AfterJump;
    }

    public void JumpToTile()
    {
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<Rigidbody>().AddForce(player.transform.up * power);
        jumpSound.Play();
    }

    public void AfterJump()
    {
        playerMoveScript.enabled = true;
        playerMoveScript.canMove = true;
        QuestClear = true;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            player.GetComponent<Rigidbody>().useGravity = false;

            hitGroundSound.Play();

            transformChange.MoveStart();
        }
    }
}
