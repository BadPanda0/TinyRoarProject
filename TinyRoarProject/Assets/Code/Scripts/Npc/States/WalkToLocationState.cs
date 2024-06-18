using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToLocationState : IState
{

    private Npc _npc;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private Vector3 _lastposition = Vector3.zero;

    public float StuckTime = 0f;

    public WalkToLocationState(Npc npc, NavMeshAgent navMeshAgent, Animator animator)
    {
        _npc = npc;
        _navMeshAgent = navMeshAgent;
        _animator = animator;
    }

    public void OnEnter()
    {
        _lastposition = Vector3.zero;
        _navMeshAgent.enabled = true;
        _navMeshAgent.SetDestination(_npc.Target);
        _animator.SetFloat("SpeedF", 0.5f);
    }

    public void OnExit()
    {
        StuckTime = 0f;
        _navMeshAgent.enabled = false;
        _npc.Target = Vector3.zero;
        _animator.SetFloat("SpeedF", 0f);
    }

    public void Tick()
    {
        if (Vector3.Distance(_npc.transform.position, _lastposition) <= 0f)
            StuckTime += Time.deltaTime;

        _lastposition = _npc.transform.position;
    }
}
