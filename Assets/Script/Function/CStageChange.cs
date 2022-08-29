using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

[System.Serializable]
public class CStageChange
{
    [SerializeField]
    private bool transformEffectShow;

    [SerializeField]
    public CTransformChange transformChange;

    [SerializeField]
    public GameObject toBigCube;

    [SerializeField]
    private string changeTargetScene;


    public void SceneChangeEffect()
    {
        if(transformEffectShow)
        {
            toBigCube.SetActive(true);
            transformChange.MoveStart();
            transformChange.endTransformEvent += BlackInOut.Instance.ReadyToChangeScene;
        }

        if (changeTargetScene == "Octahedron")
        {
            CStageManager stageManager = CStageManager.Instance;
            stageManager.octahedron = true;
        }

        CPlaySoundEvent soundEvent = CPlaySoundEvent.Instance;
        soundEvent.PlayStageChangeSoundEffect();

        BlackInOut blackInOut = BlackInOut.Instance;
        blackInOut.ChangeTargetScene = changeTargetScene;
        blackInOut.FadeOut();
    }
}



