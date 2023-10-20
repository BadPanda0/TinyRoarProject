using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Npc npc = other.GetComponent<Npc>();
        if (npc != null)
        {
            //points to add
        }

    }

    private void AddPoints(float pointsToAdd)
    {
        //add points to manager
    }

    private void ReturnToPool(Npc npc)
    {
        //Return to pool
    }

}
