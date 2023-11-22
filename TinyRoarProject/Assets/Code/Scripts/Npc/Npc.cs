using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour, IInteractable
{
    public Vector3 Target { get; set; }
    public bool BeingHold = false;

    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private PlayerDetector _playerDetector;
    private NavMeshAgent _navMeshAgent;
    private StateMaschine _stateMaschine;
    
    [SerializeField]public int ScoreToAdd = 5;

    private void Awake()
    {
       _rb.freezeRotation = true;
    }

    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _stateMaschine = new StateMaschine();

        var getRandomLocation = new GetRandomLocationState(this, this.transform.position);
        var walkToLocation = new WalkToLocationState(this, _navMeshAgent, _animator);
        var wait = new WaitState(_animator);
        var flee = new FleeState(this, _playerDetector, _navMeshAgent, _animator);
        var carryed = new CarryedState(this, _navMeshAgent, _animator, _rb, _playerDetector);
        var throwed = new ThrowedState(this, _animator, _rb);
        var stunned = new StunnedState(_animator, _playerDetector);

        AddTransition(getRandomLocation, walkToLocation, HasTarget());
        AddTransition(walkToLocation, getRandomLocation, IsStuck());
        AddTransition(walkToLocation, wait, HasReachedDestination());
        AddTransition(wait, getRandomLocation, HasWaited());
        AddTransition(flee, wait, PlayerLost());
        AddTransition(carryed, throwed, IsThrowed());
        AddTransition(throwed, stunned, IsStunned());
        AddTransition(stunned, getRandomLocation, WasStunned());

        AddAnyTransition(carryed, IsCarryed());
        AddAnyTransition(flee, PlayerDetected());

        _stateMaschine.SetState(getRandomLocation);

        void AddTransition(IState to, IState from, Func<bool> condition) => _stateMaschine.AddTransition(to, from, condition);
        void AddAnyTransition(IState to, Func<bool> condition) => _stateMaschine.AddAnyTransition(to, condition);

        Func<bool> HasTarget() => () => Target != Vector3.zero;
        Func<bool> IsStuck() => () => walkToLocation.StuckTime > 2f;
        Func<bool> HasReachedDestination() => () => Target != Vector3.zero && Vector3.Distance(transform.position, Target) < 1f;
        Func<bool> HasWaited() => () => wait.HasWaited;
        Func<bool> PlayerDetected() => () => _playerDetector.IsPlayerInRange;
        Func<bool> PlayerLost() => () => !_playerDetector.IsPlayerInRange;
        Func<bool> IsCarryed() => () => BeingHold;
        Func<bool> IsThrowed() => () => !BeingHold;
        Func<bool> IsStunned() => () => throwed.Landed;
        Func<bool> WasStunned() => () => stunned.WasStunned;
    }

    private void Update() => _stateMaschine.Tick();

    public void Interact(PlayerInteract playerInteract)
    {
        BeingHold = !BeingHold;
        if(BeingHold)
        {
            playerInteract.HeldObject = this.gameObject;
        }
        else
        {
            playerInteract.HeldObject = null;
        }
    }
}
