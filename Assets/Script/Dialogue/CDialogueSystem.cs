using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class TextData
{
    public string[] textList;
    public int nowTextNum = 0;

    public string GetNowText()
    {
        if(nowTextNum >= textList.Length)
        {
            nowTextNum = 0;
            return null;
        }
        else
            return textList[nowTextNum];
    }
}

public class CDialogueSystem : CSingleton<CDialogueSystem>
{
    private TextMeshProUGUI textMeshProUGUI;
    private float textSpeed;
    private string textContent;
    private bool isTalking = false;

    private CCharacter talkingCharacter;
    private CPlaySoundEvent soundEvent;

    public TextData textData;
    public CDialogueObj dialogueUI;

    private CUIManager uIManager;

    public override void Start()
    {
        soundEvent = CPlaySoundEvent.Instance;
        uIManager = CUIManager.Instance;
    }

    public void SetDialogueInfo(CCharacter a_talkingCharacter, TextMeshProUGUI a_textMesh, float a_textSpeed, TextData a_textData)
    {
        textMeshProUGUI = a_textMesh;
        textSpeed = a_textSpeed;
        textData = a_textData;
        talkingCharacter = a_talkingCharacter;
    }

    public void WriteText()
    {
        textMeshProUGUI.text = "";
        textContent = textData.GetNowText();
        if(textContent != null)
        {
            if(textContent.Split(";")[0] == "waitText")
            {
                dialogueUI.gameObject.SetActive(false);
                StartCoroutine(WaitTime(float.Parse(textContent.Split(";")[1])));
            }
            else if (textContent.Split(";")[0] == "ChangePos")
            {
                DIALOGUESTYLE dialogueStyle;

                switch (textContent.Split(";")[1])
                {
                    case "UP_LEFT":
                        dialogueStyle = DIALOGUESTYLE.UP_LEFT;
                        break;
                    case "UP_RIGHT":
                        dialogueStyle = DIALOGUESTYLE.UP_RIGHT;
                        break;
                    case "UP_MIDDLE":
                        dialogueStyle = DIALOGUESTYLE.UP_MIDDLE;
                        break;
                    case "DOWN_LEFT":
                        dialogueStyle = DIALOGUESTYLE.DOWN_LEFT;
                        break;
                    case "DOWN_RIGHT":
                        dialogueStyle = DIALOGUESTYLE.DOWN_RIGHT;
                        break;
                    case "DOWN_MIDDLE":
                        dialogueStyle = DIALOGUESTYLE.DOWN_MIDDLE;
                        break;
                    case "OBJCENTER":
                        dialogueStyle = DIALOGUESTYLE.OBJCENTER;
                        break;
                    default:
                        dialogueStyle = talkingCharacter.questComponent.dialogueStyle;
                        break;
                }

                dialogueUI.ChangeDialoguePos(dialogueStyle);
            }
            else
            {
                dialogueUI.gameObject.SetActive(true);
                uIManager.uiCanInteract = false;
                isTalking = true;
                StartCoroutine(TextEffect());
            }
        }
        else
        {
            if (talkingCharacter.nextEventApplyQuest != null)
                talkingCharacter.NextEvent(talkingCharacter.nextEventApplyQuest);
            else
                talkingCharacter.NextEvent();

            dialogueUI.gameObject.SetActive(false);
            uIManager.uiCanInteract = true;
        }
    }

    public void WriteAllText()
    {
        StopAllCoroutines();
        textMeshProUGUI.text = textContent;
        isTalking = false;
    }

    IEnumerator TextEffect()
    {
        textMeshProUGUI.text = "";
        foreach (char letter in textContent.ToCharArray())
        {
            textMeshProUGUI.text += letter;
            soundEvent.PlayPlayerTalkSoundEffect();
            yield return new WaitForSeconds(textSpeed);
        }
        isTalking = false;
    }

    IEnumerator WaitTime(float a_time)
    {
        yield return new WaitForSeconds(a_time);
        textData.nowTextNum++;
        WriteText();
    }

    public override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.Space) && dialogueUI != null && dialogueUI.gameObject.activeSelf)
        {
            if(isTalking)
            {
                WriteAllText();
            }
            else
            {
                textData.nowTextNum++;
                WriteText();
            }
        }
    }
}