using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;

    ScoreKeeper scoreKeeper;

    public static Health instance;

    void Awake()
    {
        instance = this;
    }

    void Start() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        instance = this;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            AudioPlayer.instance.PlayTakingDamageClip();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    void TakeDamage(int damage)
    {
        health -= damage; 
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        } else
        {
            LevelManager.instance.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(CameraShake.instance != null && applyCameraShake)
        {
            CameraShake.instance.Play();
        }
    }
}