using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleSceneChanger : Singleton<SimpleSceneChanger>
{
    public Image fader;

    public int LevelIndex;

    private IEnumerator FadeScene(int index, float duration, float waitTime, CanvasType _canvasType)
    {
        fader.gameObject.SetActive(true);
        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, t));
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(index);

        GAME_MANAGER.instance.afterScreen = false;

        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, t));
            yield return null;
            CanvasManager.Instance.SwitchCanvas(_canvasType);
            fader.gameObject.SetActive(false);
        }
    }

    #region Scenes
    public void StartGame()
    {
        StartCoroutine(FadeScene(1, 0.2f, 0.3f, CanvasType.GameUI));
        LevelIndex = 1;
        GAME_MANAGER.instance.playerDead = false;
        AudioManager.instance.Play("GameStart");
        BGMManager.Instance.Play("BGM01");
    }

    public void Level2()
    {
        StartCoroutine(FadeScene(4, 0.2f, 0.3f, CanvasType.GameUI));
        LevelIndex = 4;
        //AudioManager.instance.Play();
        //BGMManager.instance.Play()
    }
    public void Level3()
    {
        StartCoroutine(FadeScene(5, 0.2f, 0.3f, CanvasType.GameUI));
        //AudioManager.instance.Play();
        //BGMManager.instance.Play()
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        instance.StartCoroutine(instance.FadeScene(0, 0.2f, 0.3f, CanvasType.MainMenu));
        GAME_MANAGER.Instance.ResumeGame();
        BGMManager.Instance.Stop("BGM01");
    }

    public void RetryLevel()
    {
        StartCoroutine(FadeScene(SceneManager.GetActiveScene().buildIndex, 0.2f, 0.3f, CanvasType.GameUI));
        GAME_MANAGER.instance.playerDead = false;
        CanvasManager.Instance.TurnOffSecondaryCanvas(CanvasType.GameOver);
    }
    public static void SummaryScreen(int levelIndex)
    {
        instance.StartCoroutine(instance.FadeScene(levelIndex, 0.2f, 0.3f, CanvasType.EndScreen));
    }

    public static void CommunityScreen()
    {
        instance.StartCoroutine(instance.FadeScene(3, 0.2f, 0.3f, CanvasType.CommunityScreen));
    }

    public void NextLevel()
	{
        switch(LevelIndex)
		{
            case 1:
                Level2();
                break;
            case 4:
                Level3();
                break;
		}
	}
    #endregion
}
