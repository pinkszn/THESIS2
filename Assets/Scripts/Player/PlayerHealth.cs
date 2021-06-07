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
    private void Update()
    {
        IsAlive();
    }
    void IsAlive()
    {
        if (CurrentHealth <= 0)
        {
            CanvasManager.Instance.SecondaryCanvas(CanvasType.GameOver);
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
