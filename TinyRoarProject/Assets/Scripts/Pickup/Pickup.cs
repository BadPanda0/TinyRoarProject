using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float speedToAdd = 1f;
    public float duration = 1f;

    [SerializeField] private GameObject visuals;
    private bool active = true;

    public void Setup(Vector3 transform)
    {
        gameObject.transform.position = transform;
        visuals.SetActive(true);
        gameObject.SetActive(true);
        active = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (active)
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                visuals.SetActive(false);
                active = false;
                StartCoroutine(SetSpeed(playerMovement));
            }
        }
    }

    IEnumerator SetSpeed(PlayerMovement playerMovement)
    {
        playerMovement.speed += speedToAdd;
        yield return new WaitForSeconds(duration);
        playerMovement.speed -= speedToAdd;
        gameObject.SetActive(false);
        // return to pool
    }
}
