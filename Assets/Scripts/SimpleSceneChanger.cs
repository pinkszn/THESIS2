using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleSceneChanger : Singleton<SimpleSceneChanger>
{
    public Image fader;

    public int TutorialIndex;
    public int Level01Index;
    public int Level02Index;
    public int Level03Index;

    public int LevelIndex;

    private IEnumerator FadeScene(int index, float duration, float waitTime, CanvasType _canvasType, bool isAfterScreen)
    {
        fader.gameObject.SetActive(true);
        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, t));
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(index);

        GAME_MANAGER.instance.afterScreen = isAfterScreen;

        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, t));
            yield return null;
            CanvasManager.Instance.SwitchCanvas(_canvasType);
            fader.gameObject.SetActive(false);
        }

        GAME_MANAGER.instance.playerDead = false;
    }

    #region Scenes

    public void TutorialLevel()
    {
        StartCoroutine(FadeScene(TutorialIndex, 0.2f, 0.3f, CanvasType.GameUI, false));
        LevelIndex = TutorialIndex;
        AudioManager.instance.Play("GameStart");
        BGMManager.Instance.Play("BGM01");
        ItemManager.instance.InitializeData();
        //AudioManager.instance.Play();
        //BGMManager.instance.Play()
    }
    public void Level1()
    {
        StartCoroutine(FadeScene(Level01Index, 0.2f, 0.3f, CanvasType.GameUI,false));
        LevelIndex = Level01Index;
        ItemManager.instance.InitializeData();
        //AudioManager.instance.Play();
        //BGMManager.instance.Play()
    }
    public void Level2()
    {
        StartCoroutine(FadeScene(Level02Index, 0.2f, 0.3f, CanvasType.GameUI,false));
        LevelIndex = Level02Index;
        ItemManager.instance.UpdateData();
        //AudioManager.instance.Play();
        //BGMManager.instance.Play()
    }

    public void Level3()
    {
        StartCoroutine(FadeScene(Level03Index, 0.2f, 0.3f, CanvasType.ToBeContinued, false));
        ItemManager.instance.UpdateData();
        //AudioManager.instance.Play();
        //BGMManager.instance.Play()
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        instance.StartCoroutine(instance.FadeScene(0, 0.2f, 0.3f, CanvasType.MainMenu,true));
        GAME_MANAGER.Instance.ResumeGame();
        BGMManager.Instance.Stop("BGM01");
    }

    public void RetryLevel()
    {
        StartCoroutine(FadeScene(SceneManager.GetActiveScene().buildIndex, 0.2f, 0.3f, CanvasType.GameUI,false));
        ItemManager.instance.InitializeData();
        CanvasManager.Instance.TurnOffSecondaryCanvas(CanvasType.GameOver);
    }
    public static void SummaryScreen()
    {
        instance.StartCoroutine(instance.FadeScene(5, 0.2f, 0.3f, CanvasType.EndScreen,true));
    }

    public static void CommunityScreen()
    {
        instance.StartCoroutine(instance.FadeScene(6, 0.2f, 0.3f, CanvasType.CommunityScreen,true));
    }

    public void NextLevel()
	{
        switch(LevelIndex)
		{
            case 1:
                Level1();
                break;
            case 2:
                Level2();
                break;
            case 3:
                Level3();
                break;
		}

        GAME_MANAGER.instance.afterScreen = false;
    }
    #endregion
}
