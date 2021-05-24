using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "PLAYER")
		{
			//Pickup object then add the amount of items in the item manager
			Debug.Log("pickup item");
			Destroy(gameObject);
		}
	}
}
