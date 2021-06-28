using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	enum EnemyType
	{
		Recyclable,
		Decomposable,
		NonDecomposable
	};

	[SerializeField] EnemyType enemyType;

	Animator animator;
	private string currentState;

	[SerializeField] EnemyScriptableObjectBase enemy;

	//ANIMATION STATES
	const string CHASE = "Chase";
	const string ATTACK = "Attack";
	const string DIE = "Die";
	const string MUTATE = "Mutate";
	const string IDLE = "Idle";

    [SerializeField] float maxHealth = 3;
    [SerializeField] float currentHealth;

	public GameObject Player;
	Rigidbody2D rb;
	Vector2 movement;

	public float moveSpeed;
    public float damage;

	float distanceFromPlayer;
	[SerializeField] float playerRange = 3f;
	[SerializeField] float attackRange;

	bool isMoving;
	bool isAttacking;

    private void Awake()
    {
		animator = GetComponent<Animator>();
		currentHealth = maxHealth;
	}

    private void Start()
	{
		Player = GameObject.FindGameObjectWithTag("PLAYER");
		rb = GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
		distanceFromPlayer = Vector2.Distance(transform.position, Player.transform.position);

		ChaseState();
	}

	private void FixedUpdate()
	{
		
	}
	public void TakeDamage(float damage, float knockbackStrength,string PlayerAttackType)
	{
		Vector2 direction = Player.transform.position - transform.position;

		if (enemyType.ToString() == PlayerAttackType)
		{
			currentHealth -= damage;
			rb.AddForce(-direction.normalized * knockbackStrength, ForceMode2D.Impulse);

			Invoke("ResetKnockBack", 0.25f);
		}
		else
		{
			
		}

		if (currentHealth <= 0)
		{
			Die();
		}
	}
	
	public void BaseballBatDamage(float damage, float knockbackStrength)
	{
		Vector2 direction = Player.transform.position - transform.position;

		currentHealth -= damage;
		rb.AddForce(-direction.normalized * knockbackStrength, ForceMode2D.Impulse);

		Invoke("ResetKnockBack", 0.25f);
		
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public void EcoBrickKnockBack(GameObject EcoBrick, float knockbackStrength)
	{
		Vector2 direction = EcoBrick.transform.position - transform.position;
		rb.AddForce(-direction.normalized * knockbackStrength, ForceMode2D.Impulse);

		Invoke("ResetKnockBack", 0.25f);
	}

	void ResetKnockBack()
	{
		rb.velocity = Vector2.zero;
	}

	public void CarpetSlowDown(float slowAmount)
	{
		moveSpeed = moveSpeed * (1f - slowAmount);
	}

	public void ResetSlowDown()
	{
		moveSpeed = 2f;
	}

	private void Die()
	{
		Debug.Log("Enemy Died");

		//animator.SetBool("IsDead", true);
		//GetComponent<Collider2D>().enabled = false;
		//gameObject.SetActive(false);

		GAME_MANAGER.instance.currentEnemiesDisposed += 1;
		Destroy(gameObject);
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

        if(distanceFromPlayer < playerRange && distanceFromPlayer > attackRange)
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
		
	}

	#endregion

	private void OnDrawGizmosSelected()
	{
		Gizmos.DrawWireSphere(transform.position, playerRange);
		Gizmos.DrawWireSphere(transform.position, attackRange);
	}
}
