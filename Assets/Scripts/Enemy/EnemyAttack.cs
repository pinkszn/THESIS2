using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Enemy
{
    [SerializeField] protected int damage;

    [SerializeField] protected float attackRange = 1;

    private float nextAttackTime;
    [SerializeField] private float attackRate = 0.25f; //The interval of attack animation to do when you spam the left click

    [SerializeField] LayerMask playerLayers;

    float distanceFromPlayer;

    private void Update()
	{
        distanceFromPlayer = Vector2.Distance(transform.position, Player.transform.position);
        CheckAttack();
    }

    void CheckAttack()
    {
        if(distanceFromPlayer < attackRange)
		{
            if (Time.time > nextAttackTime)
            {
                StartCoroutine("AttackHit"); //Do Attack Function
                nextAttackTime = Time.time + 1f / attackRate; //sets the interval of the next attack anim 
			}
		}
        if(distanceFromPlayer > attackRange)
		{
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

	IEnumerator AttackHit()
    {
        ChangeAnimationState(ATTACK);

        Collider2D hitPlayer = Physics2D.OverlapCircle(transform.position, attackRange, playerLayers);

        if(hitPlayer != null)
		{
            hitPlayer.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        yield return new WaitForSecondsRealtime(1f);

        ChangeAnimationState(IDLE);
    }
}
