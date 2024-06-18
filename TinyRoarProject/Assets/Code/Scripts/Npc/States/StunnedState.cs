using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunnedState : IState
{
    public bool WasStunned = false;

    private Animator _animator;
    private PlayerDetector _playerDetector;
    private NpcSoundManager _soundManager;

    private float _waitTime = 3f;
    private float _currentWaitTime;


    public StunnedState(Animator animator, PlayerDetector playerDetector, NpcSoundManager soundManager)
    {
        _animator = animator;
        _playerDetector = playerDetector;
        _soundManager = soundManager;
    }

    public void OnEnter()
    {
        _currentWaitTime = 0f;

        _soundManager.PlaySound(_soundManager.Stunned);

        _animator.SetBool("StunnedB", true);
    }

    public void OnExit()
    {
        WasStunned = false;
        _playerDetector.enabled = true;
        _animator.SetBool("StunnedB", false);
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
