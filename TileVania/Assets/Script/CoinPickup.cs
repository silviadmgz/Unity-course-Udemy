using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinsPickedUp;
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;

    bool wasCollected = false;

    AudioSource coinSound;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            PickUpCoin();
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
        }
    }
    
    void PickUpCoin()
    {
        coinsPickedUp++;
        coinSound = GameObject.Find("SFX AudioSource").GetComponent<AudioSource>();
        coinSound.PlayOneShot(coinPickupSFX);
        gameObject.SetActive(false);
        Destroy(gameObject);
        Debug.Log(coinsPickedUp);
    }    
}