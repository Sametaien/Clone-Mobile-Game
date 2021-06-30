using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Movement : MonoBehaviour
{

    
    public static event Action OnMovement;


    private void FixedUpdate()
    {
        OnMovement?.Invoke();
    }
    
}
