using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeletePlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
   public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("LevelSelection");
    }
}
