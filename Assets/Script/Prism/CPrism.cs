using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPrism : CCube
{
    [SerializeField]
    private bool ifBottomShow = false;

    [SerializeField]
    private CGettablePrism prismBottom;

    [SerializeField]
    private GameObject upButton;

    [SerializeField]
    private GameObject downButton;

    public override void Start()
    {
        base.Start();

        rotationInit = gameObject.transform;
        SetWallShow((int)wallNBottomNowState.x);
    }

    //버튼 클릭을 통한 회전 동작
    public override void RotateUpButtonClick()
    {
        if (!rotateStart && !ifBottomShow)
        {
            m_qTartgetRotation = SetTargetRotation(Vector3.right, m_fRotateDownAngle);

            wallNBottomNowState.y++;
            wallNBottomNowState.y = wallNBottomNowState.y % wallNBottomNumSetting.y;

            upButton.SetActive(false);
            downButton.SetActive(true);

            ifBottomShow = true;
            RotateSolid();
        }
    }

    public override void RotateDownButtonClick()
    {
        if (!rotateStart && ifBottomShow)
        {
            m_qTartgetRotation = SetTargetRotation(Vector3.right, -m_fRotateDownAngle);

            wallNBottomNowState.y--;
            if (wallNBottomNowState.y < 0)
                wallNBottomNowState.y += wallNBottomNumSetting.y;

            upButton.SetActive(true);
            downButton.SetActive(false);

            ifBottomShow = false;
            RotateSolid();
        }
    }

    public override void RotateLeftButtonClick()
    {
        if (!rotateStart && !ifBottomShow)
        {
            m_qTartgetRotation = SetTargetRotation(Vector3.up, -m_fRotateAngle);

            wallNBottomNowState.x++;
            wallNBottomNowState.x = wallNBottomNowState.x % wallNBottomNumSetting.x;

            RotateSolid();
            ((CPrismBottom)prismBottom.itemPrefab).RotationState = (int)wallNBottomNowState.x;
            prismBottom.ChangeRotateState();

        }
    }

    public override void RotateRightButtonClick()
    {
        if (!rotateStart && !ifBottomShow)
        {
            m_qTartgetRotation = SetTargetRotation(Vector3.up, m_fRotateAngle);

            wallNBottomNowState.x--;
            if (wallNBottomNowState.x < 0)
                wallNBottomNowState.x += wallNBottomNumSetting.x;

            RotateSolid();
            ((CPrismBottom)prismBottom.itemPrefab).RotationState = (int)wallNBottomNowState.x;
            prismBottom.ChangeRotateState();
        }
    }

    public override void Update()
    {
        base.Update();

        if (rotateStart)
        {
            gameObject.transform.rotation = Quaternion.Lerp(rotationInit.rotation, m_qTartgetRotation, m_fRrotateSpeed * Time.deltaTime);
            RotateEndCheck();
        }
    }

    public override void RotateEndCheck()
    {
        float angle = Quaternion.Angle(gameObject.transform.rotation, m_qTartgetRotation);
        if (angle <= 0)
        {
            //회전 완료
            gameObject.transform.rotation = m_qTartgetRotation;
            rotateStart = false;

            SetWallShow((int)wallNBottomNowState.x);
        }
    }

   
}
