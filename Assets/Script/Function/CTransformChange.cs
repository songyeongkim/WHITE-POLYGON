using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTransformChange : CComponent
{
    public Transform changeObj;

    public Transform targetObj;

    [SerializeField]
    protected float moveSpeed;

    [SerializeField]
    protected float transformMaxTime;
    protected float transformTime;

    public bool moveStart;

    public delegate void EndTransformEvent();
    public EndTransformEvent endTransformEvent;

    public override void Update()
    {
        if (moveStart)
        {
            transformTime += Time.deltaTime;

            changeObj.rotation = Quaternion.Lerp(changeObj.rotation, targetObj.rotation, moveSpeed * Time.deltaTime);
            changeObj.position = Vector3.Lerp(changeObj.position, targetObj.position, moveSpeed * Time.deltaTime);
            changeObj.localScale = Vector3.Lerp(changeObj.localScale, targetObj.localScale, moveSpeed * Time.deltaTime);

            ChangeEndCheck();
        }
    }

    public virtual void MoveStart()
    {
        moveStart = true;
        endTransformEvent += endEvent;
        startEvent();
    }

    public void ChangeEndCheck()
    {
        float rotateAngle = Quaternion.Angle(changeObj.rotation, targetObj.rotation);
        float moveDistance = (changeObj.position - targetObj.position).sqrMagnitude;
        float scaleChange = (changeObj.localScale - targetObj.lossyScale).sqrMagnitude;

        if ((rotateAngle <= 3f && moveDistance <= 0.01f && scaleChange <= 0.01f) || transformTime > transformMaxTime)
        {
            endTransformEvent();
        }
    }

    public virtual void startEvent()
    {
        CUIManager.Instance.transformChange = this;
    }

    public virtual void endEvent()
    {
        changeObj.rotation = targetObj.rotation;
        changeObj.position = targetObj.position;
        changeObj.localScale = targetObj.localScale;
        moveStart = false;

        CUIManager.Instance.transformChange = null;
    }

    public void SetMove(Transform a_ChangeObj, Transform a_TargetMovePos, float a_MoveSpeed)
    {
        changeObj = a_ChangeObj;
        targetObj = a_TargetMovePos;
        moveSpeed = a_MoveSpeed;
    }

}
