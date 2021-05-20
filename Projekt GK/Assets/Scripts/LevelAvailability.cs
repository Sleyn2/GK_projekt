using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelAvailability : MonoBehaviour
{
    public Button[] lvlButtons;
    public TextMeshProUGUI recordLevel1Text;
    public TextMeshProUGUI recordLevel2Text;
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for(int i = 0; i< lvlButtons.Length; i++)
        {
            if(i+2 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
        ScoreData data = SaveSystem.LoadScore();
        int recordLevel1 = data.score[0];
        int recordLevel2 = data.score[1];
        recordLevel1Text.text = "Rekord: " + recordLevel1;
        recordLevel2Text.text = "Rekord: " + recordLevel2;
    }
}
