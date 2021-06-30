using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MovementState
{
    
    
    Falling
    
}

public class Character : MonoBehaviour
{

    MovementState movementState;
    private Animator animator;
    Movement movement;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        movement = this.GetComponent<Movement>();
        

    }

    private void FixedUpdate()
    {
        PlayerMovementState();
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Falling")
        {
            movementState = MovementState.Falling;
        }
    }
    private void PlayerMovementState()
    {
        switch (movementState)
        {
            case MovementState.Falling:
                
                
                animator.SetBool("isFalling", true);
                
                break;

            default:
                break;
        }
    }
}