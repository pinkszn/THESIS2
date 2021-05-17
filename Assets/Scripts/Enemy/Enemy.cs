using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;

    public float speed;
    public float damage;

    public bool Decomposable, NonDecomposable, Recyclable;

    public void Attack()
	{

	}

    public void TakeDamage()
	{
        
	}

    public void Die()
	{

	}

    //Chase State, Attack State, Death State
}
