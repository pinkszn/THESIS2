using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Player
{
    public float attackRange;
    public float attackDamage;
    public float attackRate = 2f; //The interval of attack animation to do when you spam the left click

    public float attackResetRate = 0.7f; //Seconds of not attacking to reset to first attack animation
    public float nextAttackTime = 0.5f;
    public float AttackResetTime;

    [HideInInspector] public int attackStateCounter = 0;

    public float knockbackStrength = 1.5f;

    public bool isAttacking;
    public bool GreenBin;
    public bool RedBin;
    public bool BlueBin;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    private void Update()
	{
        AttackPosition();
        AnimatorSetValues();
	}

    void AttackPosition()
	{
        if (Input.GetAxisRaw("Horizontal") >= 0.01)
		{
            attackPoint.transform.position = new Vector2(this.transform.position.x + 0.5f,this.transform.position.y);
		}
        if (Input.GetAxisRaw("Horizontal") <= -0.01)
		{
            attackPoint.transform.position = new Vector2(this.transform.position.x - 0.5f, this.transform.position.y);
		}
        if (Input.GetAxisRaw("Vertical") >= 0.01)
        {
            attackPoint.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 0.5f);
        }
        if (Input.GetAxisRaw("Vertical") <= -0.01)
        {
            attackPoint.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.5f);
        }
    }    

    void AnimatorSetValues()
	{
        animator.SetInteger("Attack Value", attackStateCounter);
        animator.SetBool("isAttacking", isAttacking);
        animator.SetBool("GreenBin", GreenBin);
        animator.SetBool("BlueBin", BlueBin);
        animator.SetBool("RedBin", RedBin);
	}

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}