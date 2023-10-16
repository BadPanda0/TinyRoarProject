using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool IsPlayerInRange => _detectedPlayer != null;

    [SerializeField] private float _clearDelay = 3f;

    private Player _detectedPlayer;

    private void OnTriggerEnter(Collider other)
    {

        Player player = other.GetComponent<Player>();

        if (player != null)
            _detectedPlayer = player;
    }

    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();
        
        if (player != null)
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
