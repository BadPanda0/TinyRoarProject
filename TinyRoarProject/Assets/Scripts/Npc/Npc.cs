using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Npc : MonoBehaviour
{
    public Vector3 Target { get; set; }

    [SerializeField] private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private StateMaschine _stateMaschine;
    
    [SerializeField]public float Points = 5f;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        var playerDetector = gameObject.AddComponent<PlayerDetector>();
        _stateMaschine = new StateMaschine();
        
        var getRandomLocation = new GetRandomLocationState(this, this.transform.position);
        var walkToLocation = new WalkToLocationState(this, _navMeshAgent, _animator);
        var wait = new WaitState(_animator);
        var flee = new FleeState(this, playerDetector, _navMeshAgent, _animator);

        AddTransition(getRandomLocation, walkToLocation, HasTarget());
        AddTransition(walkToLocation, getRandomLocation, IsStuck());
        AddTransition(walkToLocation, wait, HasReachedDestination());
        AddTransition(wait, getRandomLocation, HasWaited());

        AddAnyTransition(flee, PlayerDetected());

        AddTransition(flee, getRandomLocation, PlayerLost());

        _stateMaschine.SetState(getRandomLocation);

        void AddTransition(IState to, IState from, Func<bool> condition) => _stateMaschine.AddTransition(to, from, condition);
        void AddAnyTransition(IState to, Func<bool> condition) => _stateMaschine.AddAnyTransition(to, condition);

        Func<bool> HasTarget() => () => Target != Vector3.zero;
        Func<bool> IsStuck() => () => walkToLocation.StuckTime > 2f;
        Func<bool> HasReachedDestination() => () => Target != Vector3.zero && Vector3.Distance(transform.position, Target) < 1f;
        Func<bool> HasWaited() => () => wait.HasWaited;
        Func<bool> PlayerDetected() => () => playerDetector.IsPlayerInRange;
        Func<bool> PlayerLost() => () => !playerDetector.IsPlayerInRange;
    }

    private void Update() => _stateMaschine.Tick();
}
