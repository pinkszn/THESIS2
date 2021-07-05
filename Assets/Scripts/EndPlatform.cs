using UnityEngine;

public class EndPlatform : MonoBehaviour
{
    [SerializeField] int LevelIndex;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		EndLevel();
	}

	void EndLevel()
	{
		SimpleSceneChanger.SummaryScreen(LevelIndex);
	}
}
