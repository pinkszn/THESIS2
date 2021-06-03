using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Player
{
    [SerializeField] protected float MaxHealth = 10.0f;
    [SerializeField] protected float CurrentHealth;

	private void Start()
	{
        CurrentHealth = MaxHealth;
	}

    void IsAlive()
    {
        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        else
            return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("COLLISSION WITH " + collision.name);
        if (collision.CompareTag("ENEMY"))
        {
            CurrentHealth -= 1;
            IsAlive(); //check if player has 0 health
            Debug.Log("Health: " + CurrentHealth + "/" + MaxHealth);
        }
    }
}
