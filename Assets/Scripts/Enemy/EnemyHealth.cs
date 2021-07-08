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

	enum ItemDrop
	{
		Aluminum,
		Plastic,
		Paper,
		Glass
	}

	[SerializeField] EnemyType enemyType;
	[SerializeField] ItemDrop ItemToDrop;
	#endregion

	GameObject dropObject;

	[SerializeField] int maxHealth = 3;
    [SerializeField] int currentHealth;

	public bool isKnockBack = false;

	private void Awake()
	{
		currentHealth = maxHealth;
	}

	private new void Update()
	{
		if (Player == null)
		{
			Player = GameObject.FindGameObjectWithTag("PLAYER");
		}
	}

	public void TakeDamage(int damage, float knockbackStrength, string PlayerAttackType)
	{
		Vector2 direction = Player.transform.position - transform.position;

		if (enemyType.ToString() == PlayerAttackType)
		{
			currentHealth -= damage;
			rb.AddForce(-direction.normalized * knockbackStrength, ForceMode2D.Impulse);
			ChangeAnimationState(HURT);
			isKnockBack = true;
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

		isKnockBack = true;
		Invoke("ResetKnockBack", 0.25f);
	}

	public void BaseballBatDamage(int damage, float knockbackStrength)
	{
		Vector2 direction = Player.transform.position - transform.position;

		currentHealth -= damage;
		rb.AddForce(-direction.normalized * knockbackStrength, ForceMode2D.Impulse);

		isKnockBack = true;
		Invoke("ResetKnockBack", 0.25f);

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void ResetKnockBack()
	{
		rb.velocity = Vector2.zero;
		isKnockBack = false;
	}

	void Die()
	{
		ChangeAnimationState(DIE);

		//yield return new WaitForSeconds(1f);

		GAME_MANAGER.instance.currentEnemiesDisposed += 1;

		int r = Random.Range(1, 5);

		for (int i = 1; i <= r; i++)
		{
			switch (ItemToDrop)
			{
				case ItemDrop.Aluminum:
					dropObject = ObjectPoolManager.Instance.GetPooledObject("PickUpAluminum");
					break;
				case ItemDrop.Paper:
					dropObject = ObjectPoolManager.Instance.GetPooledObject("PickUpPaper");
					break;
				case ItemDrop.Plastic:
					dropObject = ObjectPoolManager.Instance.GetPooledObject("PickUpPlastic");
					break;
				case ItemDrop.Glass:
					dropObject = ObjectPoolManager.Instance.GetPooledObject("PickUpGlass");
					break;
			}

			Vector2 spawnPos = transform.localPosition;
			dropObject.transform.position = spawnPos;
			dropObject.SetActive(true);
		}

		gameObject.SetActive(false);
	}
}
