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

    float volumeMusic = -10F;
    float volumeEffects = 1F;
    float startEffectsVolume;

    void Start()
    {
        int qualityCurrentIndex = QualitySettings.GetQualityLevel();
        qualityDropdown.value = qualityCurrentIndex;

        volumeEffects = PlayerPrefs.GetFloat("volumeEffects");
        volumeEffectsSlider.value = volumeEffects;
        effectsMixer.SetFloat("volume", volumeEffects);

        volumeMusic = PlayerPrefs.GetFloat("volumeMusic");
        volumeSlider.value = volumeMusic;
        audioMixer.SetFloat("volume", volumeMusic);

    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volumeMusic", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        effectsMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("volumeEffects", volume);
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
