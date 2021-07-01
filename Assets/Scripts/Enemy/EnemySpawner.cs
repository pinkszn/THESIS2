using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    [SerializeField]
    private float minSpawnInterval = 1.5f;
    [SerializeField]
    private float maxSpawnInterval = 5.0f;

    private float spawnInterval;
    private float yMax, yMin, xMax, xMin;

    private bool isSpawning = false;

    private void Start()
    {
        CalculateScreenRestrictions();
    }

    private void Update()
    {
        if (!isSpawning)
        {
            StartCoroutine(SpawnCoroutine());
        }
    }

    protected void CalculateScreenRestrictions()
    {
        Vector3 upperLeft = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        Vector3 lowerLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        yMax = upperLeft.y;
        yMin = lowerLeft.y;
        xMin = lowerLeft.x;
        xMax = upperLeft.x;
    }

    IEnumerator SpawnCoroutine()
    {
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        isSpawning = true;
        //SpawnEnemy();
        //Debug.Log("Waiting for " + spawnInterval + " seconds to spawn another enemy...");
        yield return new WaitForSeconds(spawnInterval);
        isSpawning = false;
    }

    private void SpawnEnemy()
    {
        //Get an enemy from the object pool
        GameObject enemyObject = ObjectPoolManager.Instance.GetPooledObject("Enemy");
        if (enemyObject != null)
        {
            Vector3 spawnPos = Vector3.zero;
            //spawn randomly on the four corners of the screen;
            int areaToSpawn = Random.Range(0, 4);
            switch (areaToSpawn)
            {
                case 0:
                    //spawn on the upper part
                    spawnPos = new Vector3(Random.Range(xMin, xMax), yMax);
                    break;
                case 1:
                    //spawn on the lower part
                    spawnPos = new Vector3(Random.Range(xMin, xMax), yMin);
                    break;
                case 2:
                    //spawn on the right part
                    spawnPos = new Vector3(xMax, Random.Range(yMin, yMax));
                    break;
                case 3:
                    //spawn on the left part
                    spawnPos = new Vector3(xMin, Random.Range(yMin, yMax));
                    break;
            }
            //Debug.Log("Spawning enemy in " + spawnPos);
            enemyObject.transform.position = spawnPos;
            enemyObject.SetActive(true);
        }
    }
}
