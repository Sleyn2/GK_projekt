using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public int scoreMinutes;
    public int scoreSeconds;
    private float startTime;
    private float t;
    private bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
            return;
        t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
    }
    public void finish()
    {
        finished = true;
        scoreMinutes = (int)t / 60;
        scoreSeconds = (int)t % 60;
        timerText.color = Color.yellow;
    }
}
