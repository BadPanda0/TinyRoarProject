using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownToStartState : IState
{

    private float _timer = 1f;
    private GameManager _gameManager;
    private CountdownUi _countdownUi;

    public bool NextState = false;

    public CountdownToStartState(GameManager gameManager, float duration, CountdownUi countdownUi)
    {
        _gameManager = gameManager;
        _timer = duration;
        _countdownUi = countdownUi;
    }

    public void OnEnter()
    {
        _countdownUi.UpdateText(_timer);
        _countdownUi.ShowText();
        _gameManager.InvokeStateChanged();
    }

    public void OnExit()
    {
        _countdownUi.HideText();
    }

    public void Tick()
    {
        _timer -= Time.deltaTime;
        _countdownUi.UpdateText(_timer);
        if (_timer <= 0f)
            NextState = true;
    }
}
