using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Enemy
{
	[SerializeField] float moveSpeed;

	[SerializeField] protected float detectPlayerRange = 2f;
	[SerializeField] protected float attackPlayerRange = 1f;

	float distanceFromPlayer;

	bool isKnockBack;


	private void Update()
	{
		isKnockBack = GetComponent<EnemyHealth>().isKnockBack;

		if(Player != null)
		{
			distanceFromPlayer = Vector2.Distance(transform.position, Player.transform.position);
			Chase();
		}
	}

	public void CarpetSlowDown(float slowAmount)
	{
		moveSpeed = moveSpeed * (1f - slowAmount);
	}

	public void ResetSlowDown()
	{
		moveSpeed = 2f;
	}

	void Chase()
	{
		movement = Player.transform.position - transform.position;

		if (movement.x < 0)//Left
		{
			transform.localScale = new Vector2(-1, 1);
		}
		if (movement.x > 0)//Right
		{
			transform.localScale = new Vector2(1, 1);
		}

		if (distanceFromPlayer < detectPlayerRange && distanceFromPlayer > attackPlayerRange && isKnockBack == false)
		{
			ChangeAnimationState(MOVE);
			transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);
		}
		if (distanceFromPlayer > detectPlayerRange && isKnockBack == false)
		{
			ChangeAnimationState(IDLE);
		}

		if(distanceFromPlayer < attackPlayerRange && isKnockBack == false)
		{
			ChangeAnimationState(IDLE);
		}
	}
	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, detectPlayerRange);
		Gizmos.DrawWireSphere(transform.position, attackPlayerRange);
	}
}
