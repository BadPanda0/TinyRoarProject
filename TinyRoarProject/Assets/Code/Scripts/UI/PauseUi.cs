 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUi : MonoBehaviour
{

    [SerializeField] private GameObject _menuUi;
    [SerializeField] private GameObject _optionsUi;

    public void Show()
    {
        gameObject.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Unpause()
    {
        GameManager.instance.GamePaused = false;
    }

    public void ShowOptions()
    {
        _menuUi.SetActive(false);
        _optionsUi.SetActive(true);
    }

    public void ShowMenu()
    {
        _optionsUi.SetActive(false);
        _menuUi.SetActive(true);
    }

    public void BackToMainMenu()
    {
        FadeUi.instance.FadeToLevel(SceneLoader.Scene.MainMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
