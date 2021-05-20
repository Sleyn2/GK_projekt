using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer effectsMixer;
    public Dropdown qualityDropdown;
    public Slider volumeSlider;
    public Slider volumeEffectsSlider;

    float startVolume;
    float startEffectsVolume;
    static float musicVolume;

    void Start()
    {
        int qualityCurrentIndex = QualitySettings.GetQualityLevel();
        qualityDropdown.value = qualityCurrentIndex;

        effectsMixer.GetFloat("volume", out startEffectsVolume);
        volumeEffectsSlider.value = startEffectsVolume;

        audioMixer.GetFloat("volume", out startVolume);
        volumeSlider.value = startVolume;

    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        musicVolume = volume;
    }

    public void SetEffectsVolume(float volume)
    {
        effectsMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
