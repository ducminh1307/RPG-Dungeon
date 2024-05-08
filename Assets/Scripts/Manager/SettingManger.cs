using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingManger : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    public static UnityAction<float> onSFXSliderChangedValue;
    public static UnityAction<float> onMusicSliderChangedValue;

    public static SettingManger instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    private void Start()
    {
        LoadData();        
    }

    public void SFXSliderChangedCallback()
    {
        onSFXSliderChangedValue.Invoke(sfxSlider.value);
    }

    public void MusicSliderChangedCallback()
    { 
        onMusicSliderChangedValue.Invoke(musicSlider.value);
    }

    public void LoadData()
    {
        sfxSlider.value = GameManager.soundSFXValue;
        musicSlider.value = GameManager.soundMusicValue;
    }
}
