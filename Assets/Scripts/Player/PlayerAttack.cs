using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Player
{
    [SerializeField] float attackRange;
    [SerializeField] float attackDamage;
    [SerializeField] float attackRate = 2f; //The interval of attack animation to do when you spam the left click

    float attackResetRate = 1f; //Seconds of not attacking to reset to first attack animation
    float nextAttackTime = 1f;
    float AttackResetTime = 1f;

    int attackStateCounter = 0;

    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask enemyLayers;
    
    int selectedWeapon = 0;

    private void Update()
	{
        CheckAttackInput();// This should check your inputs.
        WeaponSwitch();
	}

    void CheckAttackInput()
	{
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButton(0))
            {
                AttackState(); //Do Attack Function
                nextAttackTime = Time.time + 1f / attackRate; //sets the interval of the next attack anim
                AttackResetTime = Time.time + attackResetRate; //sets the reset time to first attack anim
            }
            if (Time.time >= AttackResetTime)
            {
                ChangeAnimationState(PLAYER_IDLE);
                attackStateCounter = 0;
            }
        }
    }        

    void AttackState()
    {
        if (attackStateCounter == 0)
        {
            AttackHit();
            ChangeAnimationState(PLAYER_ATTACK1);
            attackStateCounter++;
            return;
        }
        if (attackStateCounter == 1)
        {
            AttackHit();
            ChangeAnimationState(PLAYER_ATTACK2);
            attackStateCounter++;
            return;
        }
        if (attackStateCounter == 2)
        {
            AttackHit();
            ChangeAnimationState(PLAYER_ATTACK3);
            attackStateCounter = 0;
            return;
        }
    }

    void AttackHit()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            //Put here the damage to the enemy
        }
    }

    void WeaponSwitch()  // might do some cleaning up with the if statements
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 1)
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

    }

    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}