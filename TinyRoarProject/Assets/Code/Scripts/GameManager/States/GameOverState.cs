using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : IState
{

    private GameManager _gameManager;
    private GameUi _gameUi;
    private PauseUi _pauseUi;
    private GameOverUi _gameOverUi;
    private GameSoundManager _soundManager;

    public GameOverState(GameManager gameManager, GameOverUi gameOverUi, GameUi gameUi, PauseUi pauseUi, GameSoundManager soundManager)
    {
        _gameManager = gameManager;
        _gameOverUi = gameOverUi;
        _gameUi = gameUi;
        _pauseUi = pauseUi;
        _soundManager = soundManager;
    }

    public void OnEnter()
    {
        _gameUi.Hide();
        _pauseUi.Hide();
        _gameOverUi.Show();

        Player.Instance.PlayerInput.DisableMovement();

        _gameManager.InvokeStateChanged();

        _soundManager.PlaySound(_soundManager.GameOver);
    }

    public void OnExit()
    {
        
    }

    public void Tick()
    {

    }
}
