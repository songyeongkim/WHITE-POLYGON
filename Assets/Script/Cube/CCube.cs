using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCube : CRotatableObj, IRotateEndObservable
{
    [Header("CubeType Object Wall Check")]
    [SerializeField]
    protected Vector2 wallNBottomNumSetting;
    public Vector2 wallNBottomNowState;

    public List<IRotateObserver> observerList;

    public override void Awake()
    {
        observerList = new List<IRotateObserver>();
    }

    public void SubscribeEvent(IRotateObserver observer)
    {
        observerList.Add(observer);
    }

    public void UnSubscribeEvent(IRotateObserver observer)
    {
        observerList.Remove(observer);
    }

    public void Notify()
    {
        for (int i = 0; i < observerList.Count; i++)
        {
            observerList[i].UpdateObserver(this);
        }
    }

    public override void RotateUpButtonClick()
    {
        if (!rotateStart)
        {
            m_qTartgetRotation = SetTargetRotation(Vector3.right, m_fRotateDownAngle);

            RotateSolid();
        }
    }

    public override void RotateDownButtonClick()
    {
        if (!rotateStart)
        {
            m_qTartgetRotation = SetTargetRotation(Vector3.right, -m_fRotateDownAngle);

            RotateSolid();
        }
    }

    public override void RotateLeftButtonClick()
    {
        if (!rotateStart)
        {
            m_qTartgetRotation = SetTargetRotation(Vector3.up, -m_fRotateAngle);

            wallNBottomNowState.x++;
            wallNBottomNowState.x = wallNBottomNowState.x % wallNBottomNumSetting.y;

            RotateSolid();
        }
    }

    public override void RotateRightButtonClick()
    {
        if (!rotateStart)
        {
            m_qTartgetRotation = SetTargetRotation(Vector3.up, m_fRotateAngle);

            wallNBottomNowState.x--;
            if (wallNBottomNowState.x < 0)
                wallNBottomNowState.x += wallNBottomNumSetting.x;

            RotateSolid();
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

    public virtual void RotateEndCheck()
    {
        float angle = Quaternion.Angle(gameObject.transform.rotation, m_qTartgetRotation);
        if (angle <= 0)
        {
            gameObject.transform.rotation = m_qTartgetRotation;
            rotateStart = false;

            Notify();
        }
    }


}
