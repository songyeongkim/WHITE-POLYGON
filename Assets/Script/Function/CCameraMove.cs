using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCameraMove : CTransformChange
{
    [SerializeField]
    private Camera m_Camera;
    [SerializeField]
    private Camera[] orthoCameras;
    [SerializeField]
    private float targetCameraSize;

    private float changeorthoSizeStep;
    private bool ifSizeChange = false;
    

    public void SetCameraMove(Camera a_Camera, Transform a_TargetMovePos, float a_MoveSpeed)
    {
        m_Camera = a_Camera;
        changeObj = a_Camera.gameObject.transform;
        targetObj = a_TargetMovePos;
        moveSpeed = a_MoveSpeed;
    }

    public void SetOrthCamera()
    {
        for(int i=0;i<orthoCameras.Length;i++)
        {
            orthoCameras[i].orthographic = true;
        }
    }

    public void SetPersCamera()
    {
        for (int i = 0; i < orthoCameras.Length; i++)
        {
            orthoCameras[i].orthographic = false;
        }
    }

    public void SetTargetCamerSize()
    {
        float cameraSize = m_Camera.orthographicSize;
        changeorthoSizeStep = (cameraSize - targetCameraSize) /10;
        ifSizeChange = true;
    }

    public void ChangeOrthoSize()
    {
        for(int i =0;i<orthoCameras.Length;i++)
        {
            orthoCameras[i].orthographicSize -= changeorthoSizeStep;
        }

        if(Mathf.Abs(m_Camera.orthographicSize - targetCameraSize) < 0.1f)
        {
            for (int i = 0; i < orthoCameras.Length; i++)
            {
                orthoCameras[i].orthographicSize = targetCameraSize;
            }

            ifSizeChange = false;
        }
    }

    public override void Update()
    {
        if (moveStart)
        {
            m_Camera.gameObject.transform.rotation = Quaternion.Lerp(changeObj.rotation, targetObj.rotation, moveSpeed * Time.deltaTime);
            m_Camera.gameObject.transform.position = Vector3.Lerp(changeObj.position, targetObj.position, moveSpeed * Time.deltaTime);

            if(ifSizeChange)
            {
                ChangeOrthoSize();
            }

            ChangeEndCheck();
        }
    }

    public override void startEvent()
    {
        CUIManager.Instance.cameraMove = this;
    }

    public override void endEvent()
    {
        changeObj.rotation = targetObj.rotation;
        changeObj.position = targetObj.position;
        changeObj.localScale = targetObj.localScale;
        moveStart = false;

        CUIManager.Instance.cameraMove = null;
    }

    
}
