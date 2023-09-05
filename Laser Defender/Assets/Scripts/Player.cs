using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{    
    void Update()
    {
        
    }

    void OnMove(InputValue value)
    {
        value.Get<Vector2>();
    }
}
