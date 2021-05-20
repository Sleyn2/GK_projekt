using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePlayerPrefs : MonoBehaviour
{
    float musicVolume;
    float effectsVolume;
    // Start is called before the first frame update
   public void DeletePrefs()
    {
        musicVolume = PlayerPrefs.GetFloat("volumeMusic");
        effectsVolume = PlayerPrefs.GetFloat("volumeEffects");

        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetFloat("volumeMusic", musicVolume);
        PlayerPrefs.SetFloat("volumeEffects", effectsVolume);
        SceneManager.LoadScene("LevelSelection");
    }
}
