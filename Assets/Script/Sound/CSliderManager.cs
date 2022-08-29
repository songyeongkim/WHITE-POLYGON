using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class CSliderManager : CComponent
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private string busPath = "";

    private FMOD.Studio.Bus bus;

    public override void Start()
    {
        if(busPath != "")
        {
            bus = RuntimeManager.GetBus(busPath);
        }

        bus.getVolume(out float volum);
        slider.value = volum * slider.maxValue;

        UpdateSlider();
    }

    public void UpdateSlider()
    {
        if(slider != null)
        {
            bus.setVolume(slider.value/slider.maxValue);
        }
    }
}
