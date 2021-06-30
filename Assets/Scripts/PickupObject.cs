using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("PLAYER"))
		{
			//Pickup object then add the amount of items in the item manager
			ItemManager.Instance.plastic += 1; //only works once
			AudioManager.instance.Play("GetItem");
			Debug.Log("pickup item");
			Destroy(gameObject);
		}
	}
}
