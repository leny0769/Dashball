using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider musiqueSlider;
    public Slider effetsSonnoresSlider;


    public void Start()
    {
        audioMixer.GetFloat("Musique", out float musiqueValueForSlider);
        musiqueSlider.value = musiqueValueForSlider;

        audioMixer.GetFloat("EffetsSonores", out float effetsSonoresValueForSlider);
        effetsSonnoresSlider.value = effetsSonoresValueForSlider;
    }

    public void SetVolumeMusique(float volume)
    {
        audioMixer.SetFloat("Musique", volume);
    }


    public void SetVolumeEffetsSonores(float volume)
    {
        audioMixer.SetFloat("EffetsSonores", volume);
    }
}
