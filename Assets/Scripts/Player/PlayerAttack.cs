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

    [SerializeField] float knockbackStrength = 1.5f;

    string attackType = "Recyclable"; //Decomposable, NonDecomposable, Recyclable

    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask enemyLayers;
    
    int selectedWeapon = 0;

    [SerializeField] Transform EcoBrickProjectile;

    private void Update()
	{
        AttackPosition();
        CheckAttackInput();// This should check your inputs.
        WeaponSwitch();
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

        if(Input.GetKeyDown(KeyCode.E) && ItemManager.instance.EcoBricks > 0)
		{
            Debug.Log("Eco Brick Used");
            ThrowEcoBrick();
            ItemManager.instance.EcoBricks -= 1;
		}
    }        

    void ThrowEcoBrick() //Di ko pa alam kung paano icode ito
	{
        Transform bulletTransform = Instantiate(EcoBrickProjectile, attackPoint.position, Quaternion.identity);

        Vector3 shootDir = (attackPoint.position - this.transform.position).normalized;
        bulletTransform.GetComponent<EcoBrickBehavior>().Setup(shootDir);
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

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage,knockbackStrength,attackType);
        }
    }

    void WeaponSwitch()  // might do some cleaning up with the if statements //Papalitan ko rin yung mga attackPoint.transform
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = attackPoint.transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon >= attackPoint.transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && attackPoint.transform.childCount >= 1) // Recyclable Bin
        {
            selectedWeapon = 0;
            attackType = "Recyclable";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && attackPoint.transform.childCount >= 2) //Decomposable Bin
        {
            selectedWeapon = 1;
            attackType = "Decomposable";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && attackPoint.transform.childCount >= 3) // Non Decomposable Bin
        {
            selectedWeapon = 2;
            attackType = "NonDecomposable";
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }

    }

    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in attackPoint.transform)
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