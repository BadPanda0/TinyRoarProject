using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUi : MonoBehaviour
{

    [SerializeField] private FadeUi _fadeUi;

    void Start()
    {
        Time.timeScale = 1.0f;

        _fadeUi?.Hide();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _fadeUi?.Show();

        StartCoroutine(StartGameWithDelay());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator StartGameWithDelay()
    {
        yield return new WaitForSeconds(1);

        SceneLoader.Load(SceneLoader.Scene.GameScene);
    }
}
