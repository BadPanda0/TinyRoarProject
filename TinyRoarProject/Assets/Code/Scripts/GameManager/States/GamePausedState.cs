using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedState : IState
{
    private GameManager _gameManager;
    private PauseUi _pauseUi;

    public bool NextState = false;


    public GamePausedState(GameManager gameManager, PauseUi pauseUi)
    {
        _gameManager = gameManager;
        _pauseUi = pauseUi;

    }

    public void OnEnter()
    {
        _pauseUi.Show();

        _gameManager.InvokeStateChanged();
    }

    public void OnExit()
    {
        _pauseUi.Hide();
    }

    public void Tick()
    {

    }
}
