using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public int maxEnemies = 10;
    public float spawnInterval = 1f;

    private float difficultyTimer = 0f;
    private float difficultyInterval = 20f; 

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (true)
        {
            if (enemyCount < maxEnemies)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnInterval);

            difficultyTimer += spawnInterval;

            if (difficultyTimer >= difficultyInterval)
            {
                difficultyTimer = 0;
                IncreaseDifficulty();
            }
        }
    }

    void SpawnEnemy()
    {
        xPos = Random.Range(12, 38);
        zPos = Random.Range(3, 22);
        GameObject enemy = Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
        enemy.AddComponent<Enemy>();
        enemy.GetComponent<Enemy>().spawner = this;
        enemyCount++;
    }

    public void DecrementEnemyCount()
    {
        enemyCount--;
    }

    void IncreaseDifficulty()
    {
        spawnInterval = Mathf.Max(0.2f, spawnInterval - 0.1f); 
        maxEnemies += 2; 
        Enemy.speed += 0.1f; 
    }
}

