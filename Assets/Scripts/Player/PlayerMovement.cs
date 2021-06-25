using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Player
{
    Vector2 movement;
    Vector2 moveDir;
    Vector2 lastMoveDir;
    [SerializeField] float currentMoveSpeed = 5.0f;

	private void Update()
	{
        Movement();
    }


	void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(movement.x, movement.y).normalized;

        animator.SetFloat("Speed", movement.sqrMagnitude);

        bool isIdle = Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0;

		if (isIdle)
		{
            animator.SetBool("isMoving", false);
		}
		if(!isIdle)
		{
            lastMoveDir = moveDir;
            transform.Translate(moveDir * currentMoveSpeed * Time.deltaTime);
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetBool("isMoving", true);
        }
    }
}
