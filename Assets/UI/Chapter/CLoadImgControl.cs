using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CLoadImgControl : CComponent
{
    [SerializeField]
    private Animator fadeAnim;
    [SerializeField]
    private TextMeshProUGUI sceneChangeNameText;

    public override void Start()
    {
        fadeAnim = GetComponent<Animator>();
    }

    public void ChangeSceneText(string a_Text)
    {
        sceneChangeNameText.text = a_Text;
    }

    public void FadeIn()
    {
        fadeAnim.SetBool("FadeIn", true);
    }

    public void FadeOut()
    {
        fadeAnim.SetBool("FadeOut", true);
    }

    public void FadeInit()
    {
        fadeAnim.SetBool("FadeOut", false);
        fadeAnim.SetBool("FadeIn", false);
        gameObject.SetActive(false);
    }
}
