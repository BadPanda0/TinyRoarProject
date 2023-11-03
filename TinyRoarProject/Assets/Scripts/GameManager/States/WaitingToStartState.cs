using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingToStartState : IState
{

    private float _timer = 1f;
    private GameManager _gameManager;

    public bool NextState = false;

    public WaitingToStartState(GameManager gameManager, float duration)
    {
        _gameManager = gameManager;
        _timer = duration;
    }

    public void OnEnter()
    {
        _gameManager.InvokeStateChanged();
    }

    public void OnExit()
    {
        
    }

    public void Tick()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
            NextState = true;
    }
}
