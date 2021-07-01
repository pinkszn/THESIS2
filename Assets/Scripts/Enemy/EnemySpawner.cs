using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    enum EnemyType
	{
        Recyclable,
        Decomposable,
        NonDecomposable,
        Mutated
    };

    [SerializeField] EnemyType enemyTypeToSpawn;

    public Vector2 size;

    [SerializeField]
    private float minSpawnInterval = 1.5f;
    [SerializeField]
    private float maxSpawnInterval = 5.0f;

    private float spawnInterval;

    private bool isSpawning = false;
    [SerializeField] private int spawnLimit = 7;
    private int numberSpawned = 0;

    private void Update()
    {
        if (!isSpawning &&  numberSpawned != spawnLimit)
        {
            //StartCoroutine(SpawnCoroutine());
        }
    }

    IEnumerator SpawnCoroutine()
    {
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        isSpawning = true;
        SpawnEnemy();
        yield return new WaitForSeconds(spawnInterval);
        isSpawning = false;
    }

    private void SpawnEnemy()
    {
        GameObject enemyObject = ObjectPoolManager.Instance.GetPooledObject(enemyTypeToSpawn.ToString());
        if (enemyObject != null)
        {
            Vector2 spawnPos = transform.localPosition + new Vector3(Random.Range(-size.x / 2 , size.x / 2), Random.Range(-size.y / 2, size.y / 2), 0);
            enemyObject.transform.position = spawnPos;
            enemyObject.SetActive(true);
            numberSpawned++;
        }
    }

	private void OnDrawGizmosSelected()
	{
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(transform.localPosition, size);
	}

}
