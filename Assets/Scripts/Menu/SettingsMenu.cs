using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixerMusique;
    public AudioMixer audioMixerEffetsSonores;


    public void SetVolumeMusique(float volume)
    {
        audioMixerMusique.SetFloat("volume", volume);
    }

    public void SetVolumeEffetsSonores(float volume)
    {
        audioMixerEffetsSonores.SetFloat("volume", volume);
    }
}
