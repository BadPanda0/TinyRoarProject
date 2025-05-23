using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScoreTrigger : MonoBehaviour
{

    [SerializeField] private AudioSound _audioToPlay;

    private void OnTriggerEnter(Collider other)
    {
        Npc npc = other.GetComponent<Npc>();
        if (npc != null)
        {
            ScoreManager.instance.ManipulateScore(npc.ScoreToAdd);
            NpcPool.Instance.ReturnToPool(npc);

            _audioToPlay.PlayAudio();

            NpcManager.Instance.StartCoroutine(NpcManager.Instance.SpawnNpcAfterDelay());
        }

    }
}
