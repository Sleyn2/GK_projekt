using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelEndPoint : MonoBehaviour
{
    int nextSceneLoad;
    public GameObject levelEndScreenUI;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Zako�czenie liczenia czasu
            GameObject.Find("Player").SendMessage("finish");

            GameObject Player= GameObject.Find("Player");
            Text timerText = Player.GetComponent<Timer>().timerText;

            string timeToShow = timerText.text;
            timeText.text = "Czas uko�czenia poziomu: " + timeToShow;

            GameObject GameManagerObject = GameObject.Find("Game manager");
            int coinCount = GameManagerObject.GetComponent<GameManager>().currentCoin;
            coinText.text = "Liczba zebranych monet: " + coinCount;

            int healthCount = GameManagerObject.GetComponent<HealthManager>().currentHealth;
            healthText.text = "Liczba zachowanych szans: " + healthCount;

            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                // Add Last level completition screen to add
                Debug.Log("Win");
                //Cursor.lockState = CursorLockMode.Confined;
                //SceneManager.LoadScene("LevelSelection");
                levelEndScreenUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                //SceneManager.LoadScene("LevelSelection");
                //Cursor.lockState = CursorLockMode.Confined;
                //SceneManager.LoadScene(nextSceneLoad);
                levelEndScreenUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;

                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
                {
                    PlayerPrefs.SetInt("levelAt", nextSceneLoad);
                }
            }
            
        }
    }
}
