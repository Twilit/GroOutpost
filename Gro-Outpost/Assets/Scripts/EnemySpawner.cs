using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyTypes;

    public float initialEnemySpawnClock;
    float enemySpawnClock = 0f;
    public float enemySpawnTime = 6f;

    void Start()
    {
        enemySpawnClock = initialEnemySpawnClock;
    }

    void Update()
    {
        SpawnClock();
    }

    void SpawnClock()
    {
        if (enemySpawnClock < enemySpawnTime)
        {
            enemySpawnClock += Time.deltaTime;
        }
        else
        {
            Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], transform.position, Quaternion.identity);
            enemySpawnClock = Random.Range(0, 3);
        }
    }
}
