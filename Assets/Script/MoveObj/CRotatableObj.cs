using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CRotatableObj : CComponent
{
    [Header("Rotate Inputs Setting")]
    [SerializeField]
    protected float m_fRotateAngle;
    [SerializeField]
    protected float m_fRotateDownAngle;
    [SerializeField]
    protected float m_fRrotateSpeed;

    protected Vector3 m_vRotateDir;
    protected Quaternion m_qTartgetRotation;

    protected Transform rotationInit;
    protected bool rotateStart = false;


    [Header("Wall Info")]
    //벽면 보이는 정보
    [SerializeField]
    protected GameObject[] showingWallSides;

    protected CPlaySoundEvent soundEvent;


    public override void Start()
    {
        base.Start();

        rotationInit = gameObject.transform;
        soundEvent = CPlaySoundEvent.Instance;
    }


    protected Quaternion SetTargetRotation(Vector3 a_vRotationDir, float angle)
    {
        Quaternion targetRotation = Quaternion.AngleAxis(angle,a_vRotationDir) * gameObject.transform.rotation;

        return targetRotation;
    }

    protected Quaternion SetTargetRotation(Vector3 a_vRotationDir, float angle, Transform targetObj)
    {
        Quaternion targetRotation = Quaternion.AngleAxis(angle, a_vRotationDir) * targetObj.rotation;

        return targetRotation;
    }


    //버튼 클릭을 통한 회전 동작
    public virtual void RotateUpButtonClick()
    {
        if(!rotateStart)
        {
            m_qTartgetRotation = SetTargetRotation(Vector3.right, m_fRotateDownAngle);
            RotateSolid();
        }
    }

    public virtual void RotateDownButtonClick()
    {
        if(!rotateStart)
        {
            m_qTartgetRotation = SetTargetRotation(Vector3.right, -m_fRotateDownAngle);
            RotateSolid();
        }
    }

    public virtual void RotateLeftButtonClick()
    {
        if(!rotateStart)
        {
            m_qTartgetRotation = SetTargetRotation(Vector3.up, -m_fRotateAngle);
            RotateSolid();
        }
    }

    public virtual void RotateRightButtonClick()
    {
        if(!rotateStart)
        {
            m_qTartgetRotation = SetTargetRotation(Vector3.up, m_fRotateAngle);
            RotateSolid();
        }
    }

    //회전 시작 처리 동작은 여기에
    public void RotateSolid()
    {
        soundEvent.PlayRotateSoundEffect();
        ShowWall();
        rotateStart = true;
    }



    //회전 상태 가져오기. 특정 회전 상태일 때 퍼즐이 풀려야 한다.
    public int SendRotateState()
    {
        return 0;
    }

    //특정 회전 벽 보이기
    public void HideWall()
    {
        for (int i = 0; i < showingWallSides.Length; i++)
        {
            showingWallSides[i].SetActive(false);
        }
    }

    public void ShowWall()
    {
        for (int i = 0; i < showingWallSides.Length; i++)
        {
            showingWallSides[i].SetActive(true);
        }
    }

    public void ShowSpecificWall(int showSide)
    {
        showingWallSides[showSide].SetActive(true);
    }

    public void SetWallShow(int showSide)
    {
        HideWall();
        ShowSpecificWall(showSide);
    }

}
