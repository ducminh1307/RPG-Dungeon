using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private GameObject recommendOpenDoorUI;
    [SerializeField] private GameObject recommendOpenChestUI;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
    }

    void Start()
    {
        ClosePausePanel();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPausePanel();
        }
    }

    public void ShowRecommendOpenDoor() => recommendOpenDoorUI.SetActive(true);
    public void HideRecommendOpenDoor() => recommendOpenDoorUI.SetActive(false);
    public void ShowRecommendOpenChest() => recommendOpenChestUI.SetActive(true);
    public void HideRecommendOpenChest() => recommendOpenChestUI.SetActive(false);
    public void ShowPausePanel()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
    public void ClosePausePanel()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ShowWinPanel() 
    {
        Time.timeScale = 0;
        winPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
     }
    public void ShowLosePanel() 
    { 
        Time.timeScale = 0;
        losePanel.SetActive(true);
        Cursor.lockState= CursorLockMode.None;
    }
}
