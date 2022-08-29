using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CFadeInOut : CComponent
{
    [SerializeField]
    private RawImage image;
    [SerializeField]
    private float changeSpeed;

    private float initAlpha;

    private bool fadeInStart;
    private bool fadeOutStart;

    public delegate void EndFade();
    public EndFade endFade;

    public override void Start()
    {
        initAlpha = image.color.a;
    }

    public override void Update()
    {
        if(fadeInStart)
        {
            FadeInAlpha();
            image.color = new Color(image.color.r, image.color.g, image.color.b, initAlpha);
        }

        if (fadeOutStart)
        {
            FadeInAlpha();
            image.color = new Color(image.color.r, image.color.g, image.color.b, initAlpha);
        }
    }

    public void FadeInAlpha()
    {
        fadeInStart = true;
        initAlpha += changeSpeed;
        if(initAlpha > 1)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            fadeInStart = false;
            endFade();
        }
    }

    public void FadeOutAlpha()
    {
        fadeOutStart = true;
        initAlpha -= changeSpeed;
        if (initAlpha < 0)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
            fadeOutStart = false;
            endFade();
        }
    }

}
