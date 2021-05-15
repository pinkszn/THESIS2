using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER_CONTROL : MonoBehaviour
{
    float Health;
    float Damage;

    bool isAlive = false;
    bool isPaused = false;

    //GameObject[] weaponTypes;

    #region Player Control
    void Movement()
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        /*
         * Player gets damaged when enemy collides with player
         */
    }
    #endregion
}
