using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class COpenBoxClickEvent : QClickEvent
{
    [SerializeField]
    private CTransformChange boxSizeChange;

    [SerializeField]
    private CCameraMove cameraChange;

    [SerializeField]
    RawImage backgroundImg;

    [SerializeField]
    CFadeInOut fadeIn;

    public override void Start()
    {
        base.Start();
        EndQuestAdd += Open;
    }

    public override void CheckQuestNum()
    {
        if(talkableCharacter.DialogueNum == 0)
        {
            talkableCharacter.ShowDialogue();
        }
        else if(talkableCharacter.DialogueNum == 1)
        {
            Open();
        }
    }

    public void Open()
    {
        playSoundEvent.PlayBackToPrismSoundEffect();

        QuestClear = true;
        boxSizeChange.MoveStart();
        cameraChange.MoveStart();
        cameraChange.endTransformEvent += SetStartUI;
    }

    public void SetStartUI()
    {
        cameraChange.endTransformEvent -= SetStartUI;
        backgroundImg.gameObject.SetActive(true);
        fadeIn.FadeInAlpha();
        fadeIn.endFade += LoadPrism;
    }

    public void LoadPrism()
    {
        CSceneLoader cSceneLoader = CSceneLoader.Instance;
        cSceneLoader.LoadScene("Prism_Start");
    }

}
