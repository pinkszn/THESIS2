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
    }
}
