using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool playCrashSFX = true;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && playCrashSFX)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            playCrashSFX = false;
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("CrashReload", crashDelay);
        }
    }

    void CrashReload()
    {
        SceneManager.LoadScene(0);
    }
}