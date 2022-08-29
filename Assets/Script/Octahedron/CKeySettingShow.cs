using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CKeySettingShow : CComponent
{
    [SerializeField]
    private Animator hideAnim;

    public bool animCanStart = false;

    public override void Update()
    {
        if(animCanStart)
        {
            if(Input.anyKeyDown)
            {
                animCanStart = false;
                hideAnim.SetBool("hide", true);
            }
        }
    }
}
