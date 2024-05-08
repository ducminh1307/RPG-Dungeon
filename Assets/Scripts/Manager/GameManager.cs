using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Audio Properties

    public static float soundSFXValue = 1;
    public static float soundMusicValue = 1;

    private const string sfxValueKey = "sfxValue";
    private const string musicValueKey = "musicValue";

    #endregion

    void Awake()
    {
        if (instance != null) 
            Destroy(instance);
        else
            instance = this;

        LoadDataSetting();

        SettingManger.onMusicSliderChangedValue += MusicSliderChangedCallback;
        SettingManger.onSFXSliderChangedValue += SFXSliderChangedCallback;
    }

    private void OnDestroy()
    {
        SettingManger.onMusicSliderChangedValue -= MusicSliderChangedCallback;
        SettingManger.onSFXSliderChangedValue -= SFXSliderChangedCallback;
    }

    public void ChangeSence(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void WinGame()
    {
        UIManager.instance.ShowWinPanel();
        AudioSFXManager.instance.winSound.Play();
    }

    public void LoseGame()
    {
        UIManager.instance.ShowLosePanel();
        AudioSFXManager.instance.loseSound.Play();
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #region Audio

    public void SFXSliderChangedCallback(float sfxValue)
    {
        soundSFXValue = sfxValue;
        PlayerPrefs.SetFloat(sfxValueKey, sfxValue);
    }

    public void MusicSliderChangedCallback(float musicValue)
    {
        soundMusicValue = musicValue;
        PlayerPrefs.SetFloat(musicValueKey, musicValue);
    }

    private void LoadDataSetting()
    {
        if (PlayerPrefs.HasKey(sfxValueKey))
            soundSFXValue = PlayerPrefs.GetFloat(sfxValueKey);
        else
            PlayerPrefs.SetFloat(sfxValueKey, 1f);

        if (PlayerPrefs.HasKey(musicValueKey))
            soundMusicValue = PlayerPrefs.GetFloat(musicValueKey);
        else
            PlayerPrefs.SetFloat(musicValueKey, 1f);
    }

    #endregion
}
