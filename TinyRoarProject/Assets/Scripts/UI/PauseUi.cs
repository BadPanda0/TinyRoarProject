 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUi : MonoBehaviour
{



    public void Hide()
    {
        gameObject.SetActive(false);

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Show()
    {
        gameObject.SetActive(true);

        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Unpause()
    {
        GameManager.instance.GamePaused = false;
    }

    public void BackToMainMenu()
    {
        SceneLoader.Load(SceneLoader.Scene.MainMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
