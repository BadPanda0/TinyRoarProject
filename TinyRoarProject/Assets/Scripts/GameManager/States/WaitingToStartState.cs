using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingToStartState : IState
{

    private float _timer = 1f;
    private GameManager _gameManager;
    private FadeUi _beforeCountdownUi;

    public bool NextState = false;

    public WaitingToStartState(GameManager gameManager, float duration, FadeUi beforeCountdownUi)
    {
        _gameManager = gameManager;
        _timer = duration;
        _beforeCountdownUi = beforeCountdownUi;
    }

    public void OnEnter()
    {
        _gameManager.InvokeStateChanged();

        _beforeCountdownUi.Hide();
    }

    public void OnExit()
    {
        _beforeCountdownUi.gameObject.SetActive(false);
    }

    public void Tick()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
            NextState = true;
    }
}
