using UnityEngine;

public class Player : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D rb;

    private string currentState;

    public const string PLAYER_ATTACK1 = "Player_attack_1";
    public const string PLAYER_ATTACK2 = "Player_attack_2";
    public const string PLAYER_ATTACK3 = "Player_attack_3";
    public const string PLAYER_THROW = "Player_throw";

    public const string PLAYER_IDLE = "Player_idle";
    public const string PLAYER_RUN_R = "Player_Run_R";
    public const string PLAYER_RUN_L = "Player_Run_L";
    public const string PLAYER_RUN_UP = "Player_Run_UP";
    public const string PLAYER_RUN_DOWN = "Player_Run_DOWN";
    public const string PLAYER_DODGE = "Player_dodge";
    public const string PLAYER_DIE = "Player_die";

    //[SerializeField] GameObject GameOverCanvas;
    

    private void Update()
    {
        
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
