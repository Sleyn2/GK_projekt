using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndPoint : MonoBehaviour
{
    int nextSceneLoad;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                // Add Last level completition screen to add
                Debug.Log("Win");
                //Cursor.lockState = CursorLockMode.Confined;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("LevelSelection");
            }
            else
            {
                SceneManager.LoadScene("LevelSelection");
                //Cursor.lockState = CursorLockMode.Confined;
                Cursor.lockState = CursorLockMode.None;
                //SceneManager.LoadScene(nextSceneLoad);

                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
        }
    }
}
