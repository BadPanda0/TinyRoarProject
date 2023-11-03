using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool IsPlayerInRange => _detectedPlayer != null;

    [SerializeField] private float _clearDelay = 3f;
    [SerializeField] private SphereCollider _collider;

    private GameObject _detectedPlayer;

    private void OnEnable()
    {
        _collider.enabled = true;
    }

    private void OnDisable()
    {
        _detectedPlayer = null;
        _collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _detectedPlayer = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(ClearDetectedPlayerAfterDelay(_clearDelay));

    }

    private IEnumerator ClearDetectedPlayerAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _detectedPlayer = null;
    }

    public Vector3 GetPlayerPosition()
    {
        return _detectedPlayer?.transform.position ?? Vector3.zero;
    }

}
