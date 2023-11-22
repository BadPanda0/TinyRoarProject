using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUi : MonoBehaviour
{
    [SerializeField] private GameObject _menuUi;
    [SerializeField] private GameObject _optionsUi;

    void Start()
    {
        Time.timeScale = 1.0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        FadeUi.instance.FadeToLevel(SceneLoader.Scene.GameScene);
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

    public void QuitGame()
    {
        Application.Quit();
    }
}
