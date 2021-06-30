using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    enum Movement
    {
        Idle,
        Running,
        Falling
    }
    
    Movement movement;
    Animator animator;
    Rigidbody rb;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        movement = Movement.Running;
        rb = this.GetComponent<Rigidbody>();
        
    }


    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Falling")
        {
            movement = Movement.Falling;
        }
        if (other.tag == "FallingEnd")
        {
            movement = Movement.Running;
        }
    }

   

    void PlayerMove()
    {
        switch (movement)
        {
            case Movement.Running:
                animator.SetBool("isFalling", false);
                animator.SetBool("isRunning", true);
                break;
            case Movement.Falling:
                animator.SetBool("isRunning", false);
                animator.SetBool("isFalling", true);
                break;

            default:
                break;
        }
    }
}
