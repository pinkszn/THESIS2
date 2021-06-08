using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb;

    private string currentState;

    protected const string PLAYER_ATTACK1 = "Player_attack_1";
    protected const string PLAYER_ATTACK2 = "Player_attack_2";
    protected const string PLAYER_ATTACK3 = "Player_attack_3";
    protected const string PLAYER_THROW = "Player_throw";

    protected const string PLAYER_IDLE = "Player_idle";
    protected const string PLAYER_RUN_VERTICAL = "Player_run_VERTICAL";
    protected const string PLAYER_RUN_HORIZONTAL = "Player_run_HORIZONTAL";
    protected const string PLAYER_RUN_R = "Player_Run_R";
    protected const string PLAYER_RUN_L = "Player_Run_L";
    protected const string PLAYER_RUN_UP = "Player_Run_UP";
    protected const string PLAYER_RUN_DOWN = "Player_Run_DOWN";
    protected const string PLAYER_DODGE = "Player_dodge";
    protected const string PLAYER_DIE = "Player_die";

    //[SerializeField] GameObject GameOverCanvas;
    

    private void Update()
    {
        //Checks input for swapping weapons
        //SelectWeapon(); //Swaps the weapon corresponding the input of WeaponSwitch

        //Debug.Log(nextAttackTime);
        //Debug.Log(AttackResetTime);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeAnimationState(string newState)
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
        return;
    }
}
