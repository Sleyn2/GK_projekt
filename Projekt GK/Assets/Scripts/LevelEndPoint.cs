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
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI personalBestScoreText;
    public TextMeshProUGUI newRecordText;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Zakoñczenie liczenia czasu
            GameObject.Find("Player").SendMessage("finish");

            GameObject Player= GameObject.Find("Player");
            Text timerText = Player.GetComponent<Timer>().timerText;

            int minutesScore = Player.GetComponent<Timer>().scoreMinutes;

            int secondsScore = Player.GetComponent<Timer>().scoreSeconds;

            string timeToShow = timerText.text;
            timeText.text = "Czas ukoñczenia poziomu: " + timeToShow;

            GameObject GameManagerObject = GameObject.Find("Game manager");
            int coinCount = GameManagerObject.GetComponent<GameManager>().currentCoin;
            coinText.text = "Liczba zebranych monet: " + coinCount;

            int healthCount = GameManagerObject.GetComponent<HealthManager>().currentHealth;
            healthText.text = "Liczba zachowanych szans: " + healthCount;

            // Wynik bazowo 400 punktów, za ka¿d¹ sekundê odejmowany jest 1 punkt, ka¿da zebrana moneta dodaje 10 punktów, ka¿da zachowana szansa dodaje 30 punktów
            int score = 400 - (minutesScore * 60 + secondsScore) + coinCount*10 + healthCount * 30;
            if (score < 0)
                score = 0;
            scoreText.text = "Twój wynik: " + score;

            ScoreData savedScore = SaveSystem.LoadScore();
            int personalBestScore = savedScore.score[SceneManager.GetActiveScene().buildIndex - 2];

            personalBestScoreText.text = "Twój najlepszy wynik: " + personalBestScore;

            if (score > personalBestScore) // New record
            {
                newRecordText.gameObject.SetActive(true);
                savedScore.edit(SceneManager.GetActiveScene().buildIndex - 2, score);
                SaveSystem.SaveScore(savedScore);
            }

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
