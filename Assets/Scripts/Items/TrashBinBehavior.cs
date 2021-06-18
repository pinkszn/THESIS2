using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinBehavior : MonoBehaviour
{
    PlayerAttack playerAttack;

    public enum BinType
	{
        Recyclable,
        Decomposable,
        NonDecomposable
	};

    [SerializeField] private BinType attackType; //Decomposable, NonDecomposable, Recyclable

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = GetComponentInParent<PlayerAttack>();
    }

	private void Update()
	{
        CheckAttackInput();
	}

	// Update is called once per frame
	void CheckAttackInput()
    {
        if (Time.time >= playerAttack.nextAttackTime)
        {
            if (Input.GetMouseButton(0))
            {
                AttackState(); //Do Attack Function
                playerAttack.nextAttackTime = Time.time + 1f / playerAttack.attackRate; //sets the interval of the next attack anim
                playerAttack.AttackResetTime = Time.time + playerAttack.attackResetRate; //sets the reset time to first attack anim
            }
            if (Time.time >= playerAttack.AttackResetTime)
            {
                //playerAttack.ChangeAnimationState(playerAttack.PLAYER_IDLE);
                playerAttack.attackStateCounter = 0;
            }
        }
    }

    void AttackState()
    {
        if (playerAttack.attackStateCounter == 0)
        {
            AttackHit();
            //playerAttack.ChangeAnimationState(playerAttack.PLAYER_ATTACK2);
            playerAttack.attackStateCounter++;
            return;
        }
        if (playerAttack.attackStateCounter == 1)
        {
            AttackHit();
            //playerAttack.ChangeAnimationState(playerAttack.PLAYER_ATTACK2);
            playerAttack.attackStateCounter++;
            return;
        }
        if (playerAttack.attackStateCounter == 2)
        {
            AttackHit();
            //playerAttack.ChangeAnimationState(playerAttack.PLAYER_ATTACK3);
            playerAttack.attackStateCounter = 0;
            return;
        }
    }

    void AttackHit()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerAttack.attackPoint.position, playerAttack.attackRange, playerAttack.enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(playerAttack.attackDamage, playerAttack.knockbackStrength, attackType.ToString());
        }
    }
}
