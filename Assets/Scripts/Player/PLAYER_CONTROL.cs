using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_CONTROL : MonoBehaviour
{
    Animator animator;

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

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    //GameObject[] weaponTypes;
    private void Update()
    {
        if (isAlive())
        {
            Movement();
            CheckInputs(); // This should check your inputs.
        }
        else
        {
            GameOverCanvas.SetActive(true);
            return;
        }
         
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentHealth = MaxHealth;
        Debug.Log("Health: " + CurrentHealth + "/" + MaxHealth);
    }

    //private void FixedUpdate()
    //{

    //}

    void CheckInputs()
	{
        if(Time.time >= nextAttackTime)
		{
            if (Input.GetMouseButtonDown(0))
            {
                Attack(); //Do Attack Function
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        

        //Check inputs for 1, 2, 3, 4
        //Changing weapons of character
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
        transform.Translate(movement.normalized * currentMoveSpeed * Time.deltaTime);

        //rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);
        /*
         * W,A,S,D movement
         * lagyan pa ba natin to ng dodge? (consult with design team)
         */
    }

    void WeaponSwitch()
    {
        /*
         * Weapon type switch container
         * can switch around different types of bin
         * baka mag lagay tayo ng ring menu kapag may mga extra type tayo ng gamit like yung eco-bombs and shit
         */
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLLISSION WITH " + collision.name);
        if (collision.CompareTag("ENEMY"))
        {
            CurrentHealth -= 1;
            Debug.Log("Health: " + CurrentHealth + "/" + MaxHealth);
        }
    }

	private void OnDrawGizmosSelected()
	{
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}
