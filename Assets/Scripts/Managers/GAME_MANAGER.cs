using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_MANAGER:Singleton<GAME_MANAGER>
{
    public float timerAmount = 120f;
    public bool isPaused = false;

    public bool isAlive()
	{
        //if health is 0 or other various conditions
        // return false

        //else
        return true;
	}

    public void Pause()
	{
        if(isPaused)
		{

		}
        else
		{

		}
	}

    /*
     * THINGS TO SETUP
     * 1. TIMER
     * 2. PLAYER CONDITION IF ALIVE
     * 3. PAUSE CONDITIONS
     * 4. TO BE DISSCUSED WITH DESIGN TEAM
     * 5. Make this script and the gameobject it is attached Singleton
     */
}
