using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingToStartState : IState
{

    private float _timer = 1f;
    private GameManager _gameManager;
    private BeforeCountdownUi _beforeCountdownUi;

    public bool NextState = false;

    public WaitingToStartState(GameManager gameManager, float duration, BeforeCountdownUi beforeCountdownUi)
    {
        _gameManager = gameManager;
        _timer = duration;
        _beforeCountdownUi = beforeCountdownUi;
    }

    public void OnEnter()
    {
        _gameManager.InvokeStateChanged();

        _beforeCountdownUi.Show();
    }

    public void OnExit()
    {
        _beforeCountdownUi.Hide();
    }

    public void Tick()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
            NextState = true;
    }
}
