using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcManager : MonoBehaviour
{
    public static NpcManager Instance;

    [SerializeField] private BoxCollider _boxCollider;

    [SerializeField] public int NpcToSpawn = 3;
    [NonSerialized] public int NpcSpawned = 0;

    [SerializeField] private float _spawnIntervalMin = 10f;
    [SerializeField] private float _spawnIntervalMax = 30f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < NpcToSpawn; i++)
        {
            SpawnNpc();
        }
    }

    public IEnumerator SpawnNpcAfterDelay()
    {
        NpcSpawned++;

        float randomDuraiton = UnityEngine.Random.Range(_spawnIntervalMin, _spawnIntervalMax);
        yield return new WaitForSeconds(randomDuraiton);

        SpawnNpc();

        if (NpcSpawned < NpcToSpawn)
            StartCoroutine(SpawnNpcAfterDelay());
    }

    private void SpawnNpc()
    {
        Npc npcToSpawn = NpcPool.Instance.Get();
        npcToSpawn.transform.position = GetSpawnLocation();
        npcToSpawn.gameObject.SetActive(true);
    }

    private Vector3 GetSpawnLocation()
    {
        Vector3 randomDirection = new Vector3(
            UnityEngine.Random.Range(_boxCollider.bounds.min.x, _boxCollider.bounds.max.x),
            0,
            UnityEngine.Random.Range(_boxCollider.bounds.min.z, _boxCollider.bounds.max.z));

        //randomDirection += transform.position;

        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        if (NavMesh.SamplePosition(randomDirection, out hit, 5, 1))
        {
            finalPosition = hit.position;
        }

        Collider[] colliders = Physics.OverlapSphere(finalPosition, 1);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Npc"))
            {
                return GetSpawnLocation();
            }
        }
        return finalPosition;
    }
}
