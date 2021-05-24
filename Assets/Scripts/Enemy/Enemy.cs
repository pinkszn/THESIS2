using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	Animator animator;
	private string currentState;

	//ANIMATION STATES
	const string CHASE = "Chase";
	const string ATTACK = "Attack";
	const string DIE = "Die";
	const string MUTATE = "Mutate";
	const string IDLE = "idle";

    [SerializeField] float maxHealth = 10;
    [SerializeField] float currentHealth;

    public float speed;
    public float damage;
	Vector2 movement;

    public bool Decomposable, NonDecomposable, Recyclable;

    private void Awake()
    {
		animator = GetComponent<Animator>();
    }

    private void Start()
	{
		currentHealth = maxHealth;
	}

	public void Attack()
	{

	}

    public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		if(currentHealth <= 0)
		{
			Die();
		}
	}

    public void Die()
	{
		Debug.Log("Enemy Died");

		animator.SetBool("IsDead", true);

		GetComponent<Collider2D>().enabled = false;
		this.enabled = false;
	}

    #region ANIMATOR HELL
	void ChangeAnimationState(string newState)
    {
		//stop the same animation from interrupting itself
		if (currentState == newState) return;

		//play the animation
		animator.Play(newState, 1);

		//reassing the current state
		currentState = newState;
	}

	void ChaseState()
    {
		if (movement.x < 0)//Left
		{
			transform.localScale = new Vector2(-1, 1);
		}
		else if (movement.x > 0)//Right
		{
			transform.localScale = new Vector2(1, 1);
		}
		if (movement != null)
		{
			transform.Translate(movement * speed * Time.deltaTime);
			ChangeAnimationState(CHASE);
		}
		else
			ChangeAnimationState(IDLE);
	}

	void AttackState()
    {
		//Monster should attack within range and should stop when moving when attacking
    }

	void StaggerState()
    {

    }

	void MutateState()
    {
		//if hit with wrong damage type
    }

	void DieState()
	{
		//Die animation
	}

    #endregion
}
