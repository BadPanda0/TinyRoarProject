using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ThrowedState : IState
{

    private Npc _npc;
    private Animator _animator;
    private Rigidbody _rb;

    private float _force = 12f;

    public bool Landed = false;

    //Collider
    private Collider _collider;
    private float _currentWaitTime;
    private float _waitTime = 0.5f;


    public ThrowedState(Npc npc,Animator animator, Rigidbody rigidbody, Collider collider) 
    {
        _npc = npc;
        _animator = animator;
        _rb = rigidbody;
        _collider = collider;
    }

    public void OnEnter()
    {
        Landed = false;
        _currentWaitTime = 0f;
        _rb.useGravity = true;
        _rb.velocity = (_npc.transform.right * _force) + (_npc.transform.up * 6f);
        //animation
    }

    public void OnExit()
    {
        _rb.useGravity = false;
        _rb.velocity = Vector3.zero;
        _animator.SetBool("CarryedB", false);
    }

    public void Tick()
    {
        if ( _currentWaitTime < _waitTime )
        {
            _currentWaitTime += Time.deltaTime;
            if (_currentWaitTime > _waitTime)
            {
                _collider.enabled = true;
            }
        }
        else
        {
        Landed = Physics.Raycast(_npc.transform.position, Vector3.down, 0.1f, LayerMask.GetMask("Ground"));
        }
    }
}
