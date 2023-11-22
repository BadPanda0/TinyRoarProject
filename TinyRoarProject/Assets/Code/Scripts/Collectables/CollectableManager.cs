using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager Instance;

    [SerializeField] private BoxCollider _boxCollider;

    [SerializeField]public int StunCollectableSpawnAmount = 3;
    [NonSerialized] public int StunCollectableSpawned = 0;
    [SerializeField]public int SpeedCollectableSpawnAmount = 9;
    [NonSerialized] public int SpeedCollectableSpawned = 0;

    [SerializeField] float SpawnIntervalMin = 10f;
    [SerializeField] float SpawnIntervalMax = 30f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnStunCollectable());
        StartCoroutine(SpawnSpeedCollectable());
    }

    public IEnumerator SpawnStunCollectable()
    {
        StunCollectableSpawned++;

        float randomDuraiton = UnityEngine.Random.Range(SpawnIntervalMin, SpawnIntervalMax);
        yield return new WaitForSeconds(randomDuraiton);

        StunCollectable collectableToSpawn = StunCollectablePool.Instance.Get();
        collectableToSpawn.transform.position = GetSpawnLocation();
        collectableToSpawn.gameObject.SetActive(true);

        if (StunCollectableSpawned < StunCollectableSpawnAmount)
            StartCoroutine(SpawnStunCollectable());
    }

    public IEnumerator SpawnSpeedCollectable()
    {
        SpeedCollectableSpawned++;

        float randomDuraiton = UnityEngine.Random.Range(SpawnIntervalMin, SpawnIntervalMax);
        yield return new WaitForSeconds(randomDuraiton);

        SpeedCollectable collectableToSpawn = SpeedCollectablePool.Instance.Get();
        collectableToSpawn.transform.position = GetSpawnLocation();
        collectableToSpawn.gameObject.SetActive(true);

        if(SpeedCollectableSpawned < SpeedCollectableSpawnAmount)
            StartCoroutine(SpawnSpeedCollectable());
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

        if (NavMesh.SamplePosition(randomDirection, out hit, 10, 1))
        {
            finalPosition = hit.position;
        }

        Collider[] colliders = Physics.OverlapSphere(finalPosition, 1);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                return GetSpawnLocation();
            }
        }
        return finalPosition;
    }
}
