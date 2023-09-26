using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header ("Score")]
    [SerializeField] TextMeshProUGUI scoreText;

    void Start()
    {
        healthSlider.maxValue = Health.instance.GetHealth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = ScoreKeeper.instance.CurrentScore().ToString("000000000");
    }
}