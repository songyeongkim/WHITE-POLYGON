using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using FMODUnity;

public class CRoadChangeButton : CComponent, IStopSoundOnDestroy
{
    [Header("RotateSound")]
    [SerializeField]
    private FMODUnity.StudioEventEmitter rotateSound;

    [Header("RotateSetting")]
    [SerializeField]
    private Transform floor;

    [SerializeField]
    protected CTrainMove train;
    public CTrainMove Train
    {
        set
        {
            train = value;
        }
    }

    [SerializeField]
    private float rotateAngle;
    public float RotateAngle
    {
        set
        {
            rotateAngle = value;
        }
    }

    [SerializeField]
    private float rotateSpeed;

    public bool rotateStart;
    public bool rotateEnd;
    [SerializeField]
    private float nowRotateAngle;

    public void OnMouseOver()
    {
        if (CUIManager.Instance.CheckIfUICanInteract() && !EventSystem.current.IsPointerOverGameObject())
        {
            CUIManager.Instance.ApplyPointerCursorImg();
        }
    }

    public void OnMouseExit()
    {
        if (CUIManager.Instance.CheckIfUICanInteract() && !EventSystem.current.IsPointerOverGameObject())
        {
            CUIManager.Instance.ApplyNormalCursor();
        }
    }

    public virtual void OnMouseDown()
    {
        Debug.Log("click");

        if (train.CanRotate && CUIManager.Instance.CheckIfUICanInteract() && !EventSystem.current.IsPointerOverGameObject())
        {
            rotateStart = true;
            rotateSound.Play();
        }
    }

    public override void Update()
    {
        if(rotateStart && !rotateEnd)
        {
            if(rotateAngle > 0)
            {
                nowRotateAngle += Time.deltaTime * rotateSpeed;
                if (nowRotateAngle >= rotateAngle)
                {
                    rotateStart = false;
                    rotateEnd = true;
                    nowRotateAngle = 0;
                }

                if(floor != null)
                    floor.Rotate(0, Time.deltaTime * rotateSpeed, 0);

                train.gameObject.transform.Rotate(0, 0, Time.deltaTime * rotateSpeed);
            }
            else
            {
                nowRotateAngle -= Time.deltaTime * rotateSpeed;
                if (nowRotateAngle <= rotateAngle)
                {
                    rotateStart = false;
                    rotateEnd = true;
                    nowRotateAngle = 0;
                }

                if(floor != null)
                    floor.Rotate(0, -Time.deltaTime * rotateSpeed, 0);

                train.gameObject.transform.Rotate(0, 0, -Time.deltaTime * rotateSpeed);
            }
        }

        //목표점이 바뀔 경우 처리
        if (train.DestinationChange && rotateEnd)
        {
            train.ChangeDestination();

            //목표점 바꾼 후 회전 여부와 목표점 바뀔 여부 비활성화
            train.DestinationChange = false;
            rotateStart = false;
            rotateSound.Stop();
        }
        
    }

    private void OnDestroy()
    {
        StopSound();
    }

    public void StopSound()
    {
        if(rotateSound != null)
            rotateSound.Stop();
    }
}
