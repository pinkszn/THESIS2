using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
	[SerializeField] int sceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("PLAYER"))
		{
			LoadSummaryScreen();
		}
	}

	public void LoadSummaryScreen()
	{
		SimpleSceneChanger.SummaryScreen();
	}
}
