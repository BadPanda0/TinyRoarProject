using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SoundManagerUi : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;

    [SerializeField] private string _exposedVolumeToChange;

    private void Awake()
    {
        float volumeToSet = PlayerPrefs.GetFloat(_exposedVolumeToChange);

        if (volumeToSet > 0)
        {
            _slider.value = volumeToSet;
            SetVolume(volumeToSet);
        }
        else
        {
            volumeToSet = 1;
            _slider.value = volumeToSet;
            SetVolume(volumeToSet);
        }


    }

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat(_exposedVolumeToChange, Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat(_exposedVolumeToChange, volume);
    }
}
