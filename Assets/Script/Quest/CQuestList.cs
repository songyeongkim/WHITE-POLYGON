using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CQuestList : CComponent
{
    public CQuestSystem questSystem;

    public List<CCharacter> sceneCharacters;
    public List<CQuestComponent> sceneQuests;

    public override void Awake()
    {
        questSystem = CQuestSystem.Instance;
        questSystem.questList = this;

        sceneCharacters = new List<CCharacter>();
        sceneQuests = new List<CQuestComponent>();
    }

    public void SetQuestSystemInfos()
    {
        for(int i=0;i<sceneCharacters.Count;i++)
        {
            questSystem.SetCharacterInfo(sceneCharacters[i]);
        }

        for (int i = 0; i < sceneQuests.Count; i++)
        {
            questSystem.SetQuestComponentInfo(sceneQuests[i]);
        }
    }
}
