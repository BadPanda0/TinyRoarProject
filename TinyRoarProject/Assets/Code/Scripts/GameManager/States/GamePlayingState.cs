using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayingState : IState
{

    private float _timer = 1f;
    private GameManager _gameManager;
    private GameUi _gameUi;

    public bool NextState = false;


    public GamePlayingState(GameManager gameManager, float duration, GameUi gameUi) 
    {
        _gameManager = gameManager;
        _timer = duration;
        _gameUi = gameUi;
    }

    public void OnEnter()
    {
        _gameUi.Show();

        Player.Instance.PlayerInput.EnableInput();

        _gameManager.InvokeStateChanged();
    }

    public void OnExit()
    {

        Player.Instance.PlayerInput.DisableMovement();

        _gameUi.Hide();
    }

    public void Tick()
    {
        _timer -= Time.deltaTime;
        _gameManager.GamePlayingTime = _timer;
        if (_timer <= 0f)
        {
            _gameManager.GamePlayingTime = 0f;
            NextState = true;
        }
    }
}
