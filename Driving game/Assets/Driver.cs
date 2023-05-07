using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1;
    [SerializeField] float moveSpeed = 0.01f;
    [SerializeField] float slowSpeed = 0.62f;
    [SerializeField] float boostSpeed = 5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Boost Speed")
        {
            moveSpeed = boostSpeed;
        }

        if(other.tag == "Slow Speed")
        {
            moveSpeed = slowSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.fixedDeltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;

        transform.Rotate(0,0, -steerAmount);
        transform.Translate(0, moveAmount,0);

    }
}
