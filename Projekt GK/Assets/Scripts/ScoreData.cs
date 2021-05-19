using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData : MonoBehaviour
{
    public int[] score;
    public ScoreData()
    {
        score = new int[2];
        for(int i = 0 ; i < score.Length ; i++)
                score[i] = 0;
    }
    public void edit(int n, int newValue)
    {
        score[n] = newValue;
    }
}
