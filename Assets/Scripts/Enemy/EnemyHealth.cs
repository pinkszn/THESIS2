using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Enemy
{
	#region Enemy Type
	enum EnemyType
	{
		Recyclable,
		Decomposable,
		NonDecomposable,
		Mutated
	};
	[SerializeField] EnemyType enemyType;
	#endregion

	[SerializeField] float maxHealth = 3;
    [SerializeField] float currentHealth;

	private void Awake()
	{
		currentHealth = maxHealth;
	}

	public void TakeDamage(float damage, float knockbackStrength, string PlayerAttackType)
	{
		Vector2 direction = Player.transform.position - transform.position;

		if (enemyType.ToString() == PlayerAttackType)
		{
			currentHealth -= damage;
			rb.AddForce(-direction.normalized * knockbackStrength, ForceMode2D.Impulse);

			Invoke("ResetKnockBack", 0.25f);
		}

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
	void ResetKnockBack()
	{
		rb.velocity = Vector2.zero;
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
}
