using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    public AudioSound GameCountdown;
    public AudioSound GameStart;
    public AudioSound GameOver;

    public void PlaySound(AudioSound audioToPlay)
    {
        audioToPlay.PlayAudio();
    }

}
