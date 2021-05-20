using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DontDestroy : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer effectsMixer;

    void Awake()
    {
        DontDestroyOnLoad(musicMixer);
        DontDestroyOnLoad(effectsMixer);
    }
}
