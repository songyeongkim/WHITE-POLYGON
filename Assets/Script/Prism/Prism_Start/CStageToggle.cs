using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStageToggle : CComponent
{
    private CStageManager stageManager;

    [SerializeField]
    private GameObject cubeStage;
    [SerializeField]
    private GameObject octaStage;

    public override void Start()
    {
        stageManager = CStageManager.Instance;

        if (stageManager.cubeStage)
            cubeStage.SetActive(true);

        if (stageManager.octahedron)
            octaStage.SetActive(true);
        else
            octaStage.SetActive(false);
    }
}
