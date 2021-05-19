using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public Animator animator;

    [SerializeField] float maxHealth = 10;
    [SerializeField] float currentHealth;

    public float speed;
    public float damage;

    public bool Decomposable, NonDecomposable, Recyclable;

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

    //Chase State, Attack State, Death State
}
