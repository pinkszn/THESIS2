using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoBrickBehavior : MonoBehaviour
{
    public float speed = 4f;
	float DestroyTime = 2.5f;
	[SerializeField] float explosionRadius = 2;
	[SerializeField] LayerMask enemyLayers;

	float knockbackStrength = 1.5f;

	Vector3 shootDir;

	private void Start()
	{
		//transform.Translate(LaunchOffSet)
		Destroy(gameObject, DestroyTime);
	}
	public void Setup(Vector3 shootDir)
	{
		this.shootDir = shootDir;
	}
	public void Update()
	{
		transform.position += shootDir * speed * Time.deltaTime; //Gotta Change the way projectile works\

	}

	private void OnDestroy()
	{
		ExplosionRadius();
	}

	void ExplosionRadius()
	{
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius, enemyLayers);

		if(hitEnemies != null)
		{
			foreach (Collider2D enemy in hitEnemies)
			{

				//Debug.Log("We hit " + enemy.name);

				enemy.GetComponent<Enemy>().EcoBrickKnockBack(this.gameObject, knockbackStrength);
			}
		}

		Destroy(gameObject);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("ENEMY"))
		{
			ExplosionRadius();
		}
	}
}
