using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int scene;
    // Start is called before the first frame update
    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }

}
