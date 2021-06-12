using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GAME_MANAGER : Singleton<GAME_MANAGER>
{
    [SerializeField] TextMeshProUGUI[] SummaryText;

    public float timerAmount = 120f;
    public bool isPaused = false;

    public int enemiesMutated;
    public int enemiesDisposed;
    public int materialsRecycled;
    public int materialsSeperated;

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
    }

    public void SetSummaryText()
    {
        //SummaryText[0].SetText(enemiesMutated.ToString()); //Set the UI texts after enabling UI for summary
        //SummaryText[1].SetText(enemiesDisposed.ToString()); //Set the UI texts after enabling UI for summary
        SummaryText[2].SetText(materialsRecycled.ToString()); //Set the UI texts after enabling UI for summary
        //SummaryText[3].SetText(materialsSeperated.ToString()); //Set the UI texts after enabling UI for summary
    }

    #region Pause
    public void PauseButton()
    {
        PauseGame();
    }

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
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        CanvasManager.Instance.TurnOffSecondaryCanvas(CanvasType.Pause);
        isPaused = false;
    }
    #endregion Pause

    #region Recycling
    void OpenRecyclingUI()
    {
        CanvasManager.Instance.SecondaryCanvas(CanvasType.Recycling);
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
