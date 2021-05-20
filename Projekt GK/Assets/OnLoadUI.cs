using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OnLoadUI : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer effectsMixer;
    float musicVolume;
    float effectsVolume;

    // Start is called before the first frame update
    void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("volumeMusic");
        musicMixer.SetFloat("volume", musicVolume);

        effectsVolume = PlayerPrefs.GetFloat("volumeEffects");
        effectsMixer.SetFloat("volume", effectsVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
