using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;
    [SerializeField] private Slider _uiSlider;

    private void Start()
    {
        SetupSlider(_masterSlider,busPath:"bus:/Master");
        SetupSlider(_musicSlider,busPath:"bus:/Master/Music");
        SetupSlider(_sfxSlider,busPath:"bus:/Master/SFX");
        SetupSlider(_uiSlider,busPath:"bus:/Master/UI");
    }

    private void SetupSlider(Slider slider,string busPath)
    {
        RuntimeManager.GetBus(busPath).getVolume(out float volume);
        slider.value = volume;
    }

    public void SetMasterVolume()
    {
        RuntimeManager.GetBus("bus:/Master").setVolume(_masterSlider.value);
    }
    public void SetMusicVolume()
    {
        RuntimeManager.GetBus("bus:/Master/Music").setVolume(_musicSlider.value);
    }
    public void SetSfxVolume()
    {
        RuntimeManager.GetBus("bus:/Master/SFX").setVolume(_sfxSlider.value);
    }
    public void SetUIVolume()
    {
        RuntimeManager.GetBus("bus:/Master/UI").setVolume(_uiSlider.value);
    }
}