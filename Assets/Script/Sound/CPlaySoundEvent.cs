using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class CPlaySoundEvent : CComponent
{
    [Header("BGM Sounds")]
    public FMODUnity.StudioEventEmitter mainBGM;
    public FMODUnity.StudioEventEmitter lastTrain;
    public FMODUnity.StudioEventEmitter DedoBGM;


    [Header("UI Sounds")]
    [SerializeField]
    private EventReference buttonClick;

    [SerializeField]
    private EventReference rotateClick;

    [SerializeField]
    private EventReference prismClick;

    [SerializeField]
    private EventReference tradeItemON;

    [SerializeField]
    private EventReference talkSoundPlayer;

    [SerializeField]
    private EventReference itemApply;

    [SerializeField]
    private EventReference itemGet;

    [SerializeField]
    private EventReference stageChange;

    [SerializeField]
    private EventReference rotateClear;

    [SerializeField]
    private EventReference mysteriousClear;

    [SerializeField]
    private EventReference mysteriousChange;

    [SerializeField]
    private EventReference noise;

    public static CPlaySoundEvent Instance;
    public static FMODUnity.StudioEventEmitter playingBGM;

    public override void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            return;
        }
    }

    public void PlayBGM()
    {
        playingBGM.Play();
    }

    public void StopBGM()
    {
        playingBGM.Stop();
    }

    public void ChangeBgm(FMODUnity.StudioEventEmitter changeBgm)
    {
        playingBGM = changeBgm;
    }

    public void PlayButtonSoundEffect()
    {
        RuntimeManager.PlayOneShotAttached(buttonClick, gameObject);
    }

    public void PlayRotateSoundEffect()
    {
        RuntimeManager.PlayOneShotAttached(rotateClick, gameObject);
    }

    public void PlayBackToPrismSoundEffect()
    {
        RuntimeManager.PlayOneShotAttached(prismClick, gameObject);
    }

    public void PlayPlayerTalkSoundEffect()
    {
        RuntimeManager.PlayOneShotAttached(talkSoundPlayer, gameObject);
    }

    public void PlayItemApplySoundEffect()
    {
        RuntimeManager.PlayOneShotAttached(itemApply, gameObject);
    }

    public void PlayMysteriousClearSoundEffect()
    {
        RuntimeManager.PlayOneShotAttached(mysteriousClear, gameObject);
    }

    public void PlayMysteriousChangeSoundEffect()
    {
        RuntimeManager.PlayOneShotAttached(mysteriousChange, gameObject);
    }

    public void PlayStageChangeSoundEffect()
    {
        RuntimeManager.PlayOneShotAttached(stageChange, gameObject);
    }

    public void PlayItemGetSoundEffect()
    {
        RuntimeManager.PlayOneShotAttached(itemGet, gameObject);
    }

    public void PlayRotateClearSoundEffect()
    {
        RuntimeManager.PlayOneShotAttached(rotateClear, gameObject);
    }

    public void PlayTradeItemOnSoundEffect()
    {
        RuntimeManager.PlayOneShotAttached(tradeItemON, gameObject);
    }

    public void PlayNoiseSoundEffect()
    {
        RuntimeManager.PlayOneShotAttached(noise, gameObject);
    }
}
