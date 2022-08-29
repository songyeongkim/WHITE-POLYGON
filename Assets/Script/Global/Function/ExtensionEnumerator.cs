using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ExtensionEumerator : CSingleton<ExtensionEumerator>
{
    public delegate void AfterTransparent();
    public AfterTransparent afterTransparent;

    public IEnumerator MatTransparentCoroutine(GameObject a_Obj, float a_TransparentSpeed, float a_fAlpha)
    {
        yield return new WaitForEndOfFrame();
        a_fAlpha -= a_TransparentSpeed;
        if (a_fAlpha > 0f)
        {
            Debug.Log(a_fAlpha);
            a_Obj.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, a_fAlpha);
            Instance.StartCoroutine(MatTransparentCoroutine(a_Obj, a_TransparentSpeed, a_fAlpha));
        }
        else
        {
            a_fAlpha = 0;
            a_Obj.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0);
            afterTransparent();
        }
    }

    public IEnumerator FadeIn(RawImage fade)
    {
        for (float ff = 0.0f; ff <= 1.0f;)
        {
            ff += 0.2f;
            fade.color = new Color(0, 0, 0, ff);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public IEnumerator FadeOut(RawImage fade)
    {
        for (float ff = 1.0f; ff >= 0.0f;)
        {
            ff -= 0.2f;
            fade.color = new Color(0, 0, 0, ff);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
