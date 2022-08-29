using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBackToPrism : CComponent
{
    public void BackToPrism()
    {
        CPlaySoundEvent soundEvent = CPlaySoundEvent.Instance;
        soundEvent.PlayBackToPrismSoundEffect();
        CSceneLoader.Instance.LoadScene("Prism_Start");
    }
}
