using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Collectable : MonoBehaviour
{
    [SerializeField]public float Duration = 1f;

    private void OnEnable()
    {
        float randomDuration = Random.Range(50, 80);
        StartCoroutine(DisableAfterSeconds(randomDuration));
    }

    public IEnumerator DisableAfterSeconds(float duration)
    {
        yield return new WaitForSeconds(duration);
        ReturnToPool();
    }

    public abstract void ReturnToPool();

}
