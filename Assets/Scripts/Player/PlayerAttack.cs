using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : Player
{
    public float attackRange;
    public float attackDamage;
    public float attackRate = 2f; //The interval of attack animation to do when you spam the left click

    public float attackResetRate = 1f; //Seconds of not attacking to reset to first attack animation
    public float nextAttackTime = 1f;
    public float AttackResetTime = 1f;

    [HideInInspector] public int attackStateCounter = 0;

    public float knockbackStrength = 1.5f;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    [SerializeField] Transform EcoBrickProjectile;

    private void Update()
	{
        AttackPosition();
        CheckAttackInput();// This should check your inputs.
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
        if(Input.GetMouseButtonDown(1) && ItemManager.instance.EcoBricks > 0)
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

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}