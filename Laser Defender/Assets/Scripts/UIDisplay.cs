using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class UIDisplay : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header ("Score")]
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        healthSlider.maxValue = Health.instance.GetHealth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.CurrentScore().ToString("000000000");
    }
}