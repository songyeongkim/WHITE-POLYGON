using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CStageManager : CSingleton<CStageManager>
{
    [Header("TriangleRotateState")]
    public int triangleRotateState;

    [Header("Unlocked Stages")]
    public bool cubeStage = true;
    public bool octahedron = false;

    [Header("OctahedronCamPos")]
    public COctahedron octahedronState;
    public OctahedronStateInfo octahedronStateInfo;

    public override void Awake()
    {
        octahedronStateInfo = new OctahedronStateInfo();

        
    }
}
