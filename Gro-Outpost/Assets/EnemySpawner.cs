using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyTypes;

    float enemySpawnClock = 0f;
    public float enemySpawnTime = 6f;

    void Start()
    {
        enemySpawnClock = 4;
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
            Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length - 1)], transform.position, Quaternion.identity);
            enemySpawnClock = Random.Range(0, 3);
        }
    }
}
