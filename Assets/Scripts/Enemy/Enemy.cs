using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	#region Animation States
	protected Animator animator;
	private string currentState;

	protected const string MOVE = "Move";
	protected const string ATTACK = "Attack";
	protected const string DIE = "Die";
	protected const string HURT = "Hurt";
	protected const string IDLE = "Idle";
	#endregion

	protected GameObject Player;
	protected Rigidbody2D rb;
	protected Vector2 movement;

	protected bool isMoving;
	protected bool isAttacking;

	private void Start()
	{
		animator = GetComponent<Animator>();
		Player = GameObject.FindGameObjectWithTag("PLAYER");
		rb = GetComponent<Rigidbody2D>();

		ChangeAnimationState(IDLE);
	}

	#region ANIMATOR HELL
	protected void ChangeAnimationState(string newState)
    {
		//stop the same animation from interrupting itself
		if (currentState == newState) return;

		//play the animation
		animator.Play(newState, 0);

		//reassing the current state
		currentState = newState;
	}
	
	//ChangeAnimationState(CHASE);
	//ChangeAnimationState(ATTACK);
	#endregion

	
}
