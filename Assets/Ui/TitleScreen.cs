using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private Button startGameBtn;
    [SerializeField] private Button optionsBtn;
    [SerializeField] private Button creditsBtn;
    [SerializeField] private Button quitBtn;

    [SerializeField] private Animator startGameAnimator;

    [SerializeField] private GameObject startGameAnimation;
    [SerializeField] private GameObject titleScreenBg;

    [SerializeField] private GameObject _mainUI;
    [SerializeField] private GameObject _optionsUI;

    private void Start()
    {

        startGameAnimator = GetComponent<Animator>();
        
        startGameBtn.Select();
        titleScreenBg.SetActive(true);
        startGameAnimation.SetActive(false);
        
        _mainUI.SetActive(true);
        _optionsUI.SetActive(false);
    }

    public void ToggleOptionsUI()
    {
        _mainUI.SetActive(!_mainUI.activeSelf);
        _optionsUI.SetActive(!_optionsUI.activeSelf);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void QuitTheGame()
    {
        Debug.Log("Quit the Game");
        Application.Quit();
    }

    public void StartGameButton()
    {
        titleScreenBg.SetActive(false);
        startGameAnimation.SetActive(true);
    }
}
