using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSoundManager : MonoBehaviour
{

    public AudioSound Footstep;
    public AudioSound Idle;
    public AudioSound Stunned;

    public void PlaySound(AudioSound audioToPlay)
    {
        audioToPlay.PlayAudio();
    }

    public void PlayFootstep()
    {
        Footstep.PlayAudio();
    }


    public IEnumerator RandomIdleSounds()
    {
        yield return new WaitForSeconds(Random.Range(3,8));
        Idle.PlayAudio();
        StartCoroutine(RandomIdleSounds());
    }

}
