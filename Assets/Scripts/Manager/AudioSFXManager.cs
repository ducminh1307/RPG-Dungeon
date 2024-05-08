using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFXManager : MonoBehaviour
{
    public static AudioSFXManager instance;
    
    [field: SerializeField] public AudioSource runSound { get; private set; }
    [field: SerializeField] public AudioSource jumpSound { get; private set; }
    [field: SerializeField] public AudioSource attackSound { get; private set; }
    [field: SerializeField] public AudioSource openDoorSound { get; private set; }
    [field: SerializeField] public AudioSource openChestSound { get; private set; }
    [field: SerializeField] public AudioSource usePotionSound { get; private set; }
    [field: SerializeField] public AudioSource enemyDeathSound { get; private set; }
    [field: SerializeField] public AudioSource playerDeathSound { get; private set; }
    [field: SerializeField] public AudioSource winSound { get; private set; }
    [field: SerializeField] public AudioSource loseSound { get; private set; }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;

        SettingManger.onSFXSliderChangedValue += SFXSliderChangedCallback;
    }

    private void OnDestroy()
    {
        SettingManger.onSFXSliderChangedValue -= SFXSliderChangedCallback;
    }

    private void SFXSliderChangedCallback(float sfxValue)
    {
        runSound.volume = sfxValue;
        jumpSound.volume = sfxValue;
        attackSound.volume = sfxValue;
        openDoorSound.volume = sfxValue;
        openChestSound.volume = sfxValue;
        usePotionSound.volume = sfxValue;
        enemyDeathSound.volume = sfxValue;
        winSound.volume = sfxValue;
        loseSound.volume = sfxValue;
    }

    
}
