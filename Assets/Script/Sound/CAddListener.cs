using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CAddListener : CComponent
{
    [Header("listener")]
    [SerializeField]
    private FMODUnity.StudioListener listener;

    public override void Start()
    {
        CPlaySoundEvent playSoundEvent = CPlaySoundEvent.Instance;
        listener.attenuationObject = playSoundEvent.gameObject;
    }
}
