using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEndPrologue : CQuestComponent
{
    [Header("EndPrologueEffect")]
    [SerializeField]
    private ShaderEffect_BleedingColors colorEffect;
    [SerializeField]
    private ShaderEffect_CorruptedVram corruptedEffect;
    private ShaderEffect_CorruptedVram corruptedEffectReverse;
    [SerializeField]
    private float changeSpeed;
    [SerializeField]
    private float changeTime;

    [Header("EndPrologueScene")]
    [SerializeField]
    private GameObject endBlackScene;

    private float timePassed;
    private bool changeStart;
    private bool endTextShow;


    public override void Start()
    {
        playSoundEvent = CPlaySoundEvent.Instance;
        CQuestSystem.Instance.SetQuestComponentInfo(this);
        StartQuestAdd += StartCorruptedEffect;
    }

    public override void Update()
    {
        if (changeStart)
        {
            colorEffect.shift += Time.deltaTime * changeSpeed;
            corruptedEffect.shift += Time.deltaTime * changeSpeed;
            corruptedEffectReverse.shift -= Time.deltaTime * changeSpeed;

            timePassed += Time.deltaTime;

            if(timePassed > changeTime)
            {
                changeStart = false;
                endBlackScene.SetActive(true);

                endTextShow = true;
            }
        }

        if(endTextShow)
        {
            timePassed += Time.deltaTime;

            if (timePassed > (changeTime + 1.0f) && Input.anyKey)
            {
                EndText();
                endTextShow = false;
            }
        }
    }

    private void EndText()
    {
        talkableCharacter.dialogueUI.GetComponent<Canvas>().sortingOrder = 11;
        talkableCharacter.dialogueUI.ChangeDialoguePos(dialogueStyle);
        talkableCharacter.ShowDialogue();
    }

    public void StartCorruptedEffect()
    {
        playSoundEvent.StopBGM();
        playSoundEvent.PlayNoiseSoundEffect();

        colorEffect.enabled = true;
        corruptedEffect.enabled = true;
        corruptedEffectReverse = corruptedEffect.gameObject.AddComponent<ShaderEffect_CorruptedVram>();
        changeStart = true;
    }
}
