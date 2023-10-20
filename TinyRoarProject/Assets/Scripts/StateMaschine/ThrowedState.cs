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

    public ThrowedState(Npc npc,Animator animator, Rigidbody rigidbody) 
    {
        _npc = npc;
        _animator = animator;
        _rb = rigidbody;
    }

    public void OnEnter()
    {
        _rb.useGravity = true;
        _rb.velocity = (_npc.transform.forward * _force) + (_npc.transform.up * 6f);
        //animation
    }

    public void OnExit()
    {
        _rb.useGravity = false;
    }

    public void Tick()
    {
        if(_rb.useGravity)
        {
            if (_rb.velocity.magnitude <= 0.01)
            {
                Landed = true;
            }
        }
    }
}
