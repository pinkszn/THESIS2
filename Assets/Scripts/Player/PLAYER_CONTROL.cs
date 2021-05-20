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

    public int selectedWeapon = 0;

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

        WeaponSwitch(); //Checks input for swapping weapons
        //SelectWeapon(); //Swaps the weapon corresponding the input of WeaponSwitch
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
        if (Time.time >= nextAttackTime)
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

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
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

        if(Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 1)
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
        transform.Translate(movement.normalized * currentMoveSpeed * Time.deltaTime);

        //rb.MovePosition(rb.position + movement * currentMoveSpeed * Time.fixedDeltaTime);
        /*
         * W,A,S,D movement
         * lagyan pa ba natin to ng dodge? (consult with design team)
         */
    }

    

    void SelectWeapon()
    {
        int i = 0;

        foreach(Transform weapon in transform)
		{
            if(i == selectedWeapon)
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
