using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public int coinsPickedUp;
    [SerializeField] AudioClip coinPickupSFX;
    AudioSource coinSound;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            PickUpCoin();
        }
    }
    
    void PickUpCoin()
    {
        coinsPickedUp++;
        coinSound = GameObject.Find("SFX AudioSource").GetComponent<AudioSource>();
        coinSound.PlayOneShot(coinPickupSFX);
        Destroy(gameObject);
        Debug.Log(coinsPickedUp);
    }    
}