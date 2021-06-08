using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    Vector2 movement;
    [SerializeField] float currentMoveSpeed = 5.0f;
    float minMoveSpeed;
    float maxMoveSpeed;

    private void Update()
	{
        Movement();
    }


	void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        MovementAnimator();
    }

    void MovementAnimator()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        
        
        transform.Translate(movement * currentMoveSpeed * Time.deltaTime);

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            ChangeAnimationState(PLAYER_IDLE);
        }
        //else if (Input.GetAxisRaw("Horizontal") != 0) // Temporary Solution for sprite
        //{
        //    transform.Translate(movement * currentMoveSpeed * Time.deltaTime);
        //    ChangeAnimationState(PLAYER_RUN_HORIZONTAL);
        //}
        
        //else if(Input.GetAxisRaw("Vertical") == 1   ) // Animatoin is stuck
        //{
        //    transform.Translate(movement * currentMoveSpeed * Time.deltaTime);
        //    ChangeAnimationState(PLAYER_RUN_UP);
        //}
        //else if (Input.GetAxisRaw("Vertical") == -1) // Animatoin is stuck
        //{
        //    transform.Translate(movement * currentMoveSpeed * Time.deltaTime);
        //    ChangeAnimationState(PLAYER_RUN_DOWN);
        //}

    }
}
