using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GAME_MANAGER : Singleton<GAME_MANAGER>
{
    [SerializeField] TextMeshProUGUI[] SummaryText;

    public bool isPaused = false;

    public bool playerDead = false;
    public bool afterScreen = false;

    public bool Level01Clear = false;
    public bool Level02Clear = false;

    [Space]
    public int currentEnemiesMutated, TotalEnemiesMutated;
    [Space]
    public int currentEnemiesDisposed, TotalEnemiesDisposed;
    [Space]
    public int currentMaterialsRecycled, TotalMaterialsRecycled;

    public bool isAlive()
    {
        //if health is 0 or other various conditions
        // return false
        //else
        return true;
    }

    private void Update()
    {
        PauseKey();
        OpenRecyclingUI();
        SetSummaryText();
    }

    public void SetSummaryText()
    {
        SummaryText[0].SetText(currentEnemiesMutated.ToString());
        SummaryText[1].SetText(currentEnemiesDisposed.ToString());
        SummaryText[2].SetText(currentMaterialsRecycled.ToString());
    }

    public void SetTotalSummary() //call this everytime a level ends
    {
        TotalEnemiesDisposed += currentEnemiesDisposed;
        TotalEnemiesMutated += currentEnemiesMutated;
        TotalMaterialsRecycled += currentMaterialsRecycled;
    }

    public void ResetCurrentSummary() //call this when starting a new level
	{
        currentEnemiesDisposed = 0;
        currentEnemiesMutated = 0;
        currentMaterialsRecycled = 0;
	}


    #region Pause
    public void PauseKey()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            PauseGame();
        }else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        CanvasManager.Instance.SecondaryCanvas(CanvasType.Pause);
        isPaused = true;
        AudioManager.instance.Play("Paused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        CanvasManager.Instance.TurnOffSecondaryCanvas(CanvasType.Pause);
        isPaused = false;
        AudioManager.instance.Play("Unpaused");
    }
    #endregion Pause

    #region Recycling
    void OpenRecyclingUI()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            CanvasManager.Instance.SecondaryCanvas(CanvasType.Recycling);
        }
        /*
         * TO DO
         * OPEN RECYCLE PAUSE GAME (DO CRAFTING FUNCTIONS ON A COROUTINE)
         * CLOSE RECYCLE UI IF PLAYER IS DONE USING WITH A CLOSE BUTTON USE CANVAS MANAGER.CLOSECANVAS
         * 
         */
    }
    #endregion Recycling
    /*
     * THINGS TO SETUP
     * 1. TIMER
     * 2. PLAYER CONDITION IF ALIVE
     * 3. PAUSE CONDITIONS
     * 4. TO BE DISSCUSED WITH DESIGN TEAM
     * 5. Make this script and the gameobject it is attached Singleton
     */
}
