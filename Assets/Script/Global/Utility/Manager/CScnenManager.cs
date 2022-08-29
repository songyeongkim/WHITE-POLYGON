using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CScnenManager : CComponent
{
    #region public 변수
    public float m_fPlanceDistance = KDefine.DEFAULT_PLANE_DISTANCE;

    #endregion


    public static Camera UICamera
    {
        get
        {
            return Function.FindComponent<Camera>(KDefine.NAME_UI_CAMERA);
        }
    }

    public static Camera MainCamera
    {
        get
        {
            return Function.FindComponent<Camera>(KDefine.NAME_MAIN_CAMERA);
        }
    }

    public static GameObject UIRoot
    {
        get
        {
            return GameObject.Find(KDefine.NAME_UI_ROOT);
        }
    }

    public static GameObject ObjectRoot
    {
        get
        {
            return GameObject.Find(KDefine.NAME_OBLJECT_ROOT);
        }
    }

    public static GameObject CurrentSceneManager
    {
        get
        {

            return GameObject.Find(KDefine.NAME_SCENE_MANAGER);
        }
    }

    public override void Awake()
    {
        base.Awake();

        SetupUICamera();
        SetupMainCamera();

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        Screen.SetResolution(KDefine.SCREEN_WIDTH, KDefine.SCREEN_HEIGHT, false);
    }

    public override void Update()
    {
        base.Update();

        /*
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CSceneLoader.Instance.LoadSceneAsync(0, (a_oAsyncOperation) =>
            {
                Debug.LogFormat("Percent: {0}", a_oAsyncOperation.progress);
            });
        }
        */
    }

    protected void SetupUICamera()
    {
        if(CScnenManager.UICamera != null)
        {
            CScnenManager.UICamera.orthographic = true;
            CScnenManager.UICamera.orthographicSize = (KDefine.SCREEN_HEIGHT / 2.0f) * KDefine.UNIT_SCALE;
        }
    }

    protected void SetupMainCamera()
    {
        if(CScnenManager.MainCamera != null)
        {
            float fPlaneHeight = (KDefine.SCREEN_HEIGHT / 2.0f) * KDefine.UNIT_SCALE;
            float fFieldOfView = Mathf.Atan(fPlaneHeight / m_fPlanceDistance);

            CScnenManager.MainCamera.orthographic = true;
            CScnenManager.MainCamera.orthographicSize = fPlaneHeight;
            //CScnenManager.MainCamera.fieldOfView = (fFieldOfView * 2.0f) * Mathf.Rad2Deg;
            //현재 메인카메라를 orthographic으로 사용 중
        }
    }
}
