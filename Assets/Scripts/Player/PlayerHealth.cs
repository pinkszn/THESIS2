using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Player
{
    public int MaxHealth;
    public int CurrentHealth;
    int CardboardHealth;

	private void Start()
	{
        CurrentHealth = MaxHealth;
	}
    private void Update()
    {
        CardboardHealth = ItemManager.instance.CardboardHeart;
        IsAlive();
    }

    void IsAlive()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            CanvasManager.Instance.SecondaryCanvas(CanvasType.GameOver);
        }
        else
            return;
    }

    public void TakeDamage()
	{

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
