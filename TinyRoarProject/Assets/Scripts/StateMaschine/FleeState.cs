using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeState : IState
{

    private Npc _npc;
    private PlayerDetector _playerDetector;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    //private static int FleeHash = Animator.StringToHash("Flee");

    private float _initialSpeed;
    private const float FLEE_SPEED = 6f;
    private const float FLEE_DISTANCE = 5f;

    public FleeState(Npc npc, PlayerDetector playerDetector, NavMeshAgent navMeshAgent, Animator animator)
    {
        _npc = npc;
        _playerDetector = playerDetector;
        _navMeshAgent = navMeshAgent;
        _animator = animator;
    }
    public void OnEnter()
    {
        _navMeshAgent.enabled = true;
        //_animator.SetBool(FleeHash, true);
        _initialSpeed = _navMeshAgent.speed;
        _navMeshAgent.speed = FLEE_SPEED;
    }

    public void OnExit()
    {
        _navMeshAgent.speed = _initialSpeed;
        _navMeshAgent.enabled = false;
        _npc.Target = Vector3.zero;
        //_animator.SetBool(FleeHash, false);
    }

    public void Tick()
    {
        if(_navMeshAgent.remainingDistance < 1f)
        {
            var away = GetRandomPoint();
            _navMeshAgent.SetDestination(away);
        }
    }

    private Vector3 GetRandomPoint()
    {
        var playerDirection = _npc.transform.position - _playerDetector.GetPlayerPosition();
        playerDirection.Normalize();

        var endPoint = _npc.transform.position + (playerDirection * FLEE_DISTANCE);

        if(NavMesh.SamplePosition(endPoint, out var hit, 10f, 1))
        {
            return hit.position;
        }

        return _npc.transform.position;
    }
}
