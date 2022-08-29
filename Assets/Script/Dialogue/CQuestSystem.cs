using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
public class CharacterInfo
{
    public string addKey;
    public int dialogueNum;
}

[System.Serializable]
public class QuestComponentInfo
{
    public string addKey;
    public bool questStart;
    public bool questClear;
}

public class CQuestSystem : CSingleton<CQuestSystem>
{
    public Dictionary<string, CharacterInfo> characterInfos;
    public Dictionary<string, QuestComponentInfo> questComponentInfos;


    public string sceneName;

    public CQuestList questList;


    public override void Awake()
    {
        base.Awake();
        characterInfos = new Dictionary<string, CharacterInfo>();
        questComponentInfos = new Dictionary<string, QuestComponentInfo>();
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneName = scene.name;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }



    //딕셔너리에 각 정보 저장
    public void AddCharacter(CCharacter a_Character)
    {
        string addKey = sceneName + "_" + a_Character.gameObject.name + "_Ch";

        //딕셔너리에 없다면 새 항목 추가
        if(!characterInfos.ContainsKey(addKey))
        {
            CharacterInfo newCharacterInfo = new CharacterInfo();
            newCharacterInfo.addKey = addKey;
            newCharacterInfo.dialogueNum = a_Character.DialogueNum;

            characterInfos.Add(addKey, newCharacterInfo);
            questList.sceneCharacters.Add(a_Character);
        }
        else
        {
            Debug.Log(addKey + " : " + characterInfos[addKey].dialogueNum);
        }
    }

    public void AddEvent(CQuestComponent a_Quest)
    {
        string addKey = sceneName + "_" + a_Quest.gameObject.name + "_" + a_Quest.GetType().ToString();

        if (!questComponentInfos.ContainsKey(addKey))
        {
            QuestComponentInfo newQuestComponent = new QuestComponentInfo();
            newQuestComponent.addKey = addKey;
            newQuestComponent.questStart = a_Quest.QuestStart;
            newQuestComponent.questClear = a_Quest.QuestClear;

            questComponentInfos.Add(addKey, newQuestComponent);
            questList.sceneQuests.Add(a_Quest);
        }
    }

    //딕셔너리로 업데이트
    public void UpdateCharacterInfo(CCharacter a_Character)
    {
        string addKey = sceneName + "_" + a_Character.gameObject.name + "_Ch";

        if (characterInfos.ContainsKey(addKey))
        {
            characterInfos[addKey].dialogueNum = a_Character.DialogueNum;
        }
    }

    public void UpdateQuestComponentInfo(CQuestComponent a_Quest)
    {
        string addKey = sceneName + "_" + a_Quest.gameObject.name + "_" + a_Quest.GetType().ToString();

        if (questComponentInfos.ContainsKey(addKey))
        {
            questComponentInfos[addKey].questStart = a_Quest.QuestStart;
            questComponentInfos[addKey].questClear = a_Quest.QuestClear;
        }
    }

    //딕셔너리에서 정보를 찾아 적용
    public void SetCharacterInfo(CCharacter a_Character)
    {
        string addKey = sceneName + "_" + a_Character.gameObject.name + "_Ch";

        if(characterInfos.ContainsKey(addKey))
        {
            a_Character.DialogueNum = characterInfos[addKey].dialogueNum;
        }
        else
        {
            AddCharacter(a_Character);
        }
    }

    public void SetQuestComponentInfo(CQuestComponent a_Quest)
    {
        string addKey = sceneName + "_" + a_Quest.gameObject.name + "_" + a_Quest.GetType().ToString();

        if (questComponentInfos.ContainsKey(addKey))
        {
            bool tempStart;
            bool tempClear;

            tempStart = questComponentInfos[addKey].questStart;
            tempClear = questComponentInfos[addKey].questClear;

            a_Quest.QuestStart = tempStart;
            a_Quest.QuestClear = tempClear;
        }
        else
        {
            AddEvent(a_Quest);
        }

        AddQuestState(a_Quest); 
    }

    public void AddQuestState(CQuestComponent a_Quest)
    {
        a_Quest.SetActiveState();
    }
}
