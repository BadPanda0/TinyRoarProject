using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioSound Footstep;
    public AudioSound Interact;
    public AudioSound Throw;
    public AudioSound Stunned;

    public void PlaySound(AudioSound audioToPlay)
    {
        audioToPlay.PlayAudio();
    }

    public void PlayFootstep()
    {
        Footstep.PlayAudio();
    }


}
