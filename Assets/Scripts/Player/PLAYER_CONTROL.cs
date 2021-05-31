using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_CONTROL : MonoBehaviour
{

    Animator animator;
    private string currentState;

    //ANIMATION STATES
    const string PLAYER_IDLE = "Player_idle";
    const string PLAYER_RUN = "Player_run";
    const string PLAYER_DODGE = "Player_dodge";
    const string PLAYER_DIE = "Player_die";

    const string PLAYER_ATTACK1 = "Player_attack_1";
    const string PLAYER_ATTACK2 = "Player_attack_2";
    const string PLAYER_ATTACK3 = "Player_attack_3";
    const string PLAYER_THROW = "Player_throw";
    int attackStateCounter = 0;
    bool isAttacking = false;


    [SerializeField] float MaxHealth = 10.0f;
    [SerializeField] float CurrentHealth;

    [SerializeField] GameObject GameOverCanvas;
    Vector2 movement;
    Rigidbody2D rb;

    [SerializeField] float currentMoveSpeed = 5.0f;
    float minMoveSpeed;
    float maxMoveSpeed;

    [SerializeField] Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange;
    public float attackDamage;

    public float attackRate = 2f; //The interval of attack animation to do when you spam the left click
    public float attackResetRate = 1f; //Seconds of not attacking to reset to first attack animation
    float nextAttackTime = 0f;
    float AttackResetTime = 0f;

    public int selectedWeapon = 0;

    //GameObject[] weaponTypes;
    private void Update()
    {
        Debug.Log(currentState);
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (isAlive())
        {
            MovementAnimator();
            CheckInputs(); // This should check your inputs.
        }
        else
        {
            GameOverCanvas.SetActive(true);
            return;
        }

        WeaponSwitch(); //Checks input for swapping weapons
        //SelectWeapon(); //Swaps the weapon corresponding the input of WeaponSwitch

        //Debug.Log(nextAttackTime);
        //Debug.Log(AttackResetTime);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        CurrentHealth = MaxHealth;
        //Debug.Log("Health: " + CurrentHealth + "/" + MaxHealth);
    }


    void CheckInputs()
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
        

        //Check inputs for 1, 2, 3, 4
        //Changing weapons of character
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

    bool isAlive()
    {
        if (CurrentHealth <= 0)
        {
            return false;
        }
        else return true;
    }

    #region Player Controls
    void Movement()
    {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
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

    void Attack()
    {
        Debug.Log("Pressed Left Click");




        /*
         * baka gawin na lang nating animator to imbis na ganto
         * pero atm isang simpleng attack lang muna para makapag indicator na tayo for weapon types
         */


        //This detects the collision of the attack to all enemies hit
        /* animator.SetTrigger("Attack");
         * Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
		{
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
		}*/
    }
    #endregion

    #region ANIMATOR HELL
    void ChangeAnimationState(string newState)
    {
        if (newState != null)
		{
            //stop the same animation from interrupting itself
            if (currentState == newState) 
                return;

            //reassing the current state
            currentState = newState;

            //play the animation
            animator.Play(newState, 0);
        }
    }

    void MovementAnimator()
    {
        if (movement.x < 0)//Left LOCAL POSITION
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (movement.x > 0)//Right LOCAL POSITION
        {
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            ChangeAnimationState(PLAYER_IDLE);
        }
        else
        {
            transform.Translate(movement * currentMoveSpeed * Time.deltaTime);
            ChangeAnimationState(PLAYER_RUN);
        }
    }

    void AttackState()
    {
        if (attackStateCounter == 0)
        {
            ChangeAnimationState(PLAYER_ATTACK1);
            attackStateCounter++;
            return;
        }
        if (attackStateCounter == 1)
        {
            ChangeAnimationState(PLAYER_ATTACK2);
            attackStateCounter++;
            return;
        }
        if (attackStateCounter == 2)
        {
            ChangeAnimationState(PLAYER_ATTACK3);
            attackStateCounter = 0;
            return;
        }
    }


        #endregion

        private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("COLLISSION WITH " + collision.name);
        if (collision.CompareTag("ENEMY"))
        {
            CurrentHealth -= 1;
            //Debug.Log("Health: " + CurrentHealth + "/" + MaxHealth);
        }
    }

	private void OnDrawGizmosSelected()
	{
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}
