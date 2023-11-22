using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : IState
{
    public bool HasWaited = false;

    private Animator _animator;

    private float _minWaitSeconds = 3f;
    private float _maxWaitSeconds = 5f;

    private float _randomWaitTime;
    private float _currentWaitTime;


    public WaitState(Animator animator) 
    {
        _animator = animator;
    }

    public void OnEnter()
    {
        _randomWaitTime = Random.Range(_minWaitSeconds, _maxWaitSeconds);
        _currentWaitTime = 0;
    }

    public void OnExit()
    {
        HasWaited = false;
    }

    public void Tick()
    {
        _currentWaitTime += Time.deltaTime;
        if (_currentWaitTime > _randomWaitTime)
        {
            HasWaited = true;
        }
    }
}
