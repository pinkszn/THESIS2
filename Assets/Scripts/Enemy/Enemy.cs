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

	public GameObject Player;
	Vector2 movement;

	public float moveSpeed = 5f;
    public float damage;

	float distanceFromPlayer;
	float playerRange = 2f;
	float attackRange;

    public bool Decomposable, NonDecomposable, Recyclable;
	bool isMoving;
	bool isAttacking;

    private void Awake()
    {
		animator = GetComponent<Animator>();
    }

    private void Start()
	{
		currentHealth = maxHealth;
		Player = GameObject.FindGameObjectWithTag("PLAYER");
	}

    private void Update()
    {
		ChaseState();

		distanceFromPlayer = Vector2.Distance(transform.position, Player.transform.position);

		Debug.Log(distanceFromPlayer);
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
		movement = Player.transform.position - transform.position;

		if (movement.x < 0)//Left
		{
			transform.localScale = new Vector2(-1, 1);
		}
		if (movement.x > 0)//Right
		{
			transform.localScale = new Vector2(1, 1);
		}

		//if (transform.localPosition.x == 0 && transform.localPosition.y == 0)
		//{
		//	ChangeAnimationState(IDLE);
		//}

        if(distanceFromPlayer > playerRange)
        {
			ChangeAnimationState(CHASE);

			transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, moveSpeed * Time.deltaTime);

			//rb.MovePosition((Vector2)transform.position + (movement * moveSpeed * Time.deltaTime));
		}


		
	}

	void AttackState()
    {
		if(distanceFromPlayer < attackRange)
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
