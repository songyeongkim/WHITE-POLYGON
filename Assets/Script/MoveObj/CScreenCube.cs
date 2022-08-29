using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScreenCube : CCube
{
    [Header("Rotate ScreenWrite")]
    [SerializeField]
    private GameObject screenWrite;

    [Header("Quest Check")]
    [SerializeField]
    private CQuestComponent rotateQuest;
    [SerializeField]
    private int rotateQuestNum;

    public override void Update()
    {
        base.Update();

        if(rotateStart)
        {
            gameObject.transform.rotation = Quaternion.Lerp(rotationInit.rotation, m_qTartgetRotation, m_fRrotateSpeed * Time.deltaTime);
            screenWrite.transform.localRotation = Quaternion.Lerp(rotationInit.rotation, m_qTartgetRotation, m_fRrotateSpeed * Time.deltaTime);
            RotateEndCheck();
        }    
    }

    public override void RotateEndCheck()
    {
        float angle = Quaternion.Angle(gameObject.transform.rotation, m_qTartgetRotation);
        if(angle <= 0)
        {
            gameObject.transform.rotation = m_qTartgetRotation;
            screenWrite.transform.localRotation = m_qTartgetRotation;
            rotateStart = false;

            Notify();
        }
    }
}
