using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_CONTROL : MonoBehaviour
{
    [SerializeField] float Health = 10.0f;
    [SerializeField] float Damage;

    Vector2 movement;
    Transform player;
    Rigidbody2D rb;

    [SerializeField] float currentMoveSpeed = 5.0f;
    float minMoveSpeed;
    float maxMoveSpeed;

    bool isAlive = false;
    bool isPaused = false;

    //GameObject[] weaponTypes;
    private void Update()
    {
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("Health: " + Health);
    }

    private void FixedUpdate()
    {
        Movement();
    }

    #region Player Controls
    void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        transform.Translate(movement * currentMoveSpeed * Time.deltaTime);
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
        /*
         * baka gawin na lang nating animator to imbis na ganto
         * pero atm isang simpleng attack lang muna para makapag indicator na tayo for weapon types
         */
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLLISSION WITH " + collision.name);
        if (collision.CompareTag("ENEMY"))
        {
            Health -= 1;
            Debug.Log("Health: " + Health);
        }
    }
}
