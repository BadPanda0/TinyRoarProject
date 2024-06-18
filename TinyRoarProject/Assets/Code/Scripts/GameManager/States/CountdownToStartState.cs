using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownToStartState : IState
{

    private float _timer = 1f;
    private GameManager _gameManager;
    private CountdownUi _countdownUi;
    private GameSoundManager _soundManager;

    public bool NextState = false;

    public CountdownToStartState(GameManager gameManager, float duration, CountdownUi countdownUi, GameSoundManager soundManager)
    {
        _gameManager = gameManager;
        _timer = duration;
        _countdownUi = countdownUi;
        _soundManager = soundManager;
    }

    public void OnEnter()
    {
        _countdownUi.UpdateText(_timer);
        _countdownUi.ShowText();
        _gameManager.InvokeStateChanged();

        _soundManager.PlaySound(_soundManager.GameCountdown);
    }

    public void OnExit()
    {
        _countdownUi.HideText();
        _soundManager.PlaySound(_soundManager.GameStart);
    }

    public void Tick()
    {
        _timer -= Time.deltaTime;
        _countdownUi.UpdateText(_timer);
        if (_timer <= 0f)
            NextState = true;
    }
}
