using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GetRandomLocationState : IState
{

    private Npc _npc;
    private Vector3 _npcLocation;
    private float _searchRadius = 10f;

    public GetRandomLocationState(Npc npc, Vector3 npcLocation)
    {
        _npc = npc;
        _npcLocation = npcLocation;
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
       
    }

    public void Tick()
    {
        _npc.Target = SearchRandomLocation();
    }

    private Vector3 SearchRandomLocation()
    {
        Vector3 randomLocation = Random.insideUnitSphere * _searchRadius;

        randomLocation += _npcLocation;
        
        if (NavMesh.SamplePosition(randomLocation, out var hit, _searchRadius, 1))
        {
            return hit.position;
        }
        else
        {
            return randomLocation;
        }
    }
}
