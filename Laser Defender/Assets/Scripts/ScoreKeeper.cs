using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore;

    public static ScoreKeeper instance;

    void Awake()
    {
        instance = this;
    }

    public int CurrentScore()
    {
        return currentScore;
    }

    public void ModifyScore(int value)
    {
        currentScore += value;
        Mathf.Clamp(currentScore, 0, int.MaxValue);
        Debug.Log(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}