using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSceneLoader : CSingleton<CSceneLoader>
{
    //! 씬을 변경한다.
    public void LoadScene(int a_nIndex)
    {
        string oScenePath = SceneUtility.GetScenePathByBuildIndex(a_nIndex);
        this.LoadScene(oScenePath);
    }

    //! 씬을 변경한다.
    public void LoadScene(string a_oName)
    {
        SceneManager.LoadScene(a_oName, LoadSceneMode.Single);
    }

    //! 씬을 로드한다.
    public void LoadScene(int a_nIndex, LoadSceneMode a_eLoadSceneMode = LoadSceneMode.Single)
    {
        string oScenePath = SceneUtility.GetScenePathByBuildIndex(a_nIndex);
        this.LoadScene(oScenePath, a_eLoadSceneMode);
    }

    //! 씬을 로드한다.
    public void LoadScene(string a_oName, LoadSceneMode a_eLoadSceneMode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene(a_oName, LoadSceneMode.Single);
    }

    //! 씬을 로드한다.
    public void LoadSceneAsync(int a_nIndex, System.Action<AsyncOperation> a_oCallBack, float a_fDelay = 0.0f,
        LoadSceneMode a_eLoadSceneMode = LoadSceneMode.Single)
    {
        string oScenePath = SceneUtility.GetScenePathByBuildIndex(a_nIndex);
        this.LoadSceneAsync(oScenePath, a_oCallBack, a_fDelay, a_eLoadSceneMode);
    }

    //! 씬을 로드한다.
    public void LoadSceneAsync(string a_oName, System.Action<AsyncOperation> a_oCallBack, float a_fDelay = 0.0f,
        LoadSceneMode a_eLoadSceneMode = LoadSceneMode.Single)
    {
        StartCoroutine(this.DoLoadSceneAsync(a_oName, a_oCallBack, a_fDelay, a_eLoadSceneMode));
    }

    private IEnumerator DoLoadSceneAsync(string a_oName, System.Action<AsyncOperation> a_oCallBack, float a_fDelay,
        LoadSceneMode a_eLoadSceneMode)
    {
        yield return new WaitForSeconds(a_fDelay);
        var oAsyncOperation = SceneManager.LoadSceneAsync(a_oName, a_eLoadSceneMode);

        yield return Function.WaitAsyncOperation(oAsyncOperation, a_oCallBack);
    }
}
