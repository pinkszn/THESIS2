using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SimpleSceneChanger : MonoBehaviour
{
    public Image fader;

    private IEnumerator FadeScene(int index,float duration, float waitTime)
    {
        fader.gameObject.SetActive(true);
        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, t));
            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(index);

        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            fader.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, t));
            yield return null;
        }
        fader.gameObject.SetActive(false);
        CanvasManager.Instance.SwitchCanvas(CanvasType.GameUI);
    }

    public void StartGame()
    {
        StartCoroutine(FadeScene(1,1,1));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
