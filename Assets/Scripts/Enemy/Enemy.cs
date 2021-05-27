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
	public Transform Player;
    public float speed;
    public float damage;
	Vector2 movement;
	float playerRange;
	float attackRange;

    public bool Decomposable, NonDecomposable, Recyclable;
	bool isMoving;
	bool isAttacking;

    private void Awake()
    {
		animator = GetComponent<Animator>();
		//Player = GetComponent<Transform>();
    }

    private void Start()
	{
		currentHealth = maxHealth;
	}

    private void Update()
    {
		ChaseState();
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
		animator.Play(newState, 0);

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

		if (transform.localPosition.x == 0 && transform.localPosition.y == 0)
		{
			ChangeAnimationState(IDLE);
		}
        else if(Vector2.Distance(this.transform.transform.position, Player.transform.position) < playerRange)
        {
				ChangeAnimationState(CHASE);
				transform.position = Vector2.MoveTowards(gameObject.transform.position, Player.position, speed);
		}
	}

	void AttackState()
    {
		if(Vector2.Distance(this.transform.transform.position, Player.transform.position) < attackRange)
        {
			ChangeAnimationState(ATTACK);
			//attack function;
        }
		//Monster should attack within range and should stop when moving when attacking
		//if player is within range, activate attackState
		//if attackState activated, stop moving then attack
    }

	void StaggerState()
    {
		//if hit then stop moving
    }

	void MutateState()
    {
		//if hit with wrong damage type
    }

	void DieState()
	{
		//Die animation
		gameObject.SetActive(false);
	}

    #endregion
}
