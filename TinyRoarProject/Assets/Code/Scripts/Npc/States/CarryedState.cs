using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarryedState : IState
{

    private Npc _npc;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private Rigidbody _rb;
    private PlayerDetector _playerDetector;
    private Collider _collider;

    public CarryedState(Npc npc,NavMeshAgent navMeshAgent, Animator animator, Rigidbody rigidbody, PlayerDetector playerDetector, Collider collider)
    {
        _npc = npc;
        _navMeshAgent = navMeshAgent;
        _animator = animator;
        _rb = rigidbody;
        _playerDetector = playerDetector;
        _collider = collider;
    }

    public void OnEnter()
    {
        _collider.enabled = false;
        _navMeshAgent.enabled = false;
        _npc.Target = Vector3.zero;
        _rb.useGravity = false;
        _playerDetector.enabled = false;
        _animator.SetBool("CarryedB", true);
    }

    public void OnExit()
    {

    }

    public void Tick()
    {

    }
}
