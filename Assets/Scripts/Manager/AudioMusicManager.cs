using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSound;
    [SerializeField] private AudioSource buttonClickedSound;

    private void Awake()
    {
        SettingManger.onMusicSliderChangedValue += MusicSliderChangedCallback;
    }

    private void OnDestroy()
    {
        SettingManger.onMusicSliderChangedValue -= MusicSliderChangedCallback;
    }

    private void MusicSliderChangedCallback(float musicValue)
    {
        musicSound.volume = musicValue;
    }

    public void ButtonClickedCallback()
    {
        buttonClickedSound.Play();
    }
}
