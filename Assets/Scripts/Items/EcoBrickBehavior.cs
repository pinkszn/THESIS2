using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoBrickBehavior : MonoBehaviour
{
    public float speed = 4f;
    public Vector3 LaunchOffSet;
    public bool thrown;

	int DestroyTime = 5;

	private void Start()
	{
		if(thrown) //Still thinking about the logic of the projectile
		{
			//var direction = -transform.right + Vector3.up;
			//GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
		}
		transform.Translate(LaunchOffSet);

		Destroy(gameObject, DestroyTime);
	}

	public void Update()
	{
		if(!thrown)
		{
			//transform.position += -transform.right * speed * Time.deltaTime;
		}	
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		//Need to consult what will happen
	}
}
