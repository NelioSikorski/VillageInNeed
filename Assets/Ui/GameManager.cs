using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Pause")] [SerializeField] private GameObject pauseUI;
    private bool _isPaused = false;
    
    [SerializeField] private GameObject _optionsUI;
    [SerializeField] private GameObject _buttonsUI;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // --- Pause UI --- //
        pauseUI.SetActive(false);
        _optionsUI.SetActive(false);
    }

    public void ToggleUOptionsUI()
    {
        _optionsUI.SetActive(!_optionsUI.activeSelf);
        _buttonsUI.SetActive(!_buttonsUI.activeSelf);
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        if (_isPaused)
        {
            Time.timeScale = 0.0f;
            pauseUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            pauseUI.SetActive(false);
        }
    }

    public void QuitToTitleScreen()
    {
        Time.timeScale = 1.0f;
        Application.Quit();
        SceneManager.LoadScene("TitleScreen");
    }
}