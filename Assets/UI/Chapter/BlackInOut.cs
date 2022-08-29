using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BlackInOut : CComponent
{
    public GameObject blackBackPrefab;
    public GameObject blackBackUI;

    public CLoadImgControl blackBackController;

    public bool readyToChangeStage;
    private string changeTargetScene;
    public string ChangeTargetScene
    {
        set
        {
            changeTargetScene = value;
            blackBackController.ChangeSceneText(changeTargetScene);
        }
        get
        {
            return changeTargetScene;
        }
    }

    public static BlackInOut Instance;

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

    public override void Start()
    {
        //blackBackUI = Instantiate(blackBackPrefab, transform);
        blackBackUI.SetActive(false);

        blackBackController = blackBackUI.GetComponent<CLoadImgControl>();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void FadeIn()
    {
        blackBackController.FadeIn();
    }

    public void FadeOut()
    {
        blackBackUI.SetActive(true);
        blackBackController.FadeOut();
    }

    public void ReadyToChangeScene()
    {
        readyToChangeStage = true;
        LoadStage(changeTargetScene);
    }

    public void LoadStage(string stage)
    {
        readyToChangeStage = false;
        CSceneLoader.Instance.LoadSceneAsync(stage, CallBack, 0.01f);
    }

    public void CallBack(AsyncOperation asyncOperation)
    {
        if(asyncOperation.isDone)
        {
            FadeIn();
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(readyToChangeStage)
        {
            FadeIn();
        } 
    }
}
