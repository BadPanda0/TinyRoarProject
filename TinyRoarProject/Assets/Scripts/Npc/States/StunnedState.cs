using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedState : IState
{
    public bool WasStunned = false;

    private Animator _animator;
    private PlayerDetector _playerDetector;

    private float _waitTime = 3f;
    private float _currentWaitTime;


    public StunnedState(Animator animator, PlayerDetector playerDetector)
    {
        _animator = animator;
        _playerDetector = playerDetector;
    }

    public void OnEnter()
    {
        _currentWaitTime = 0f;
       //start anim
    }

    public void OnExit()
    {
        WasStunned = false;
        _playerDetector.enabled = true;
    }

    public void Tick()
    {
        _currentWaitTime += Time.deltaTime;
        if (_currentWaitTime > _waitTime)
        {
            WasStunned = true;
        }
    }
}
