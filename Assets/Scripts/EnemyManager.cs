using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public float startTimeBetweenSpawns;
    public float spawnTimeDecreaseTime;
    public float startDelay;
    public float nextSpawnTime;
    public float timeBetweenSpawns;
    
    const float MIN_TIME_BETWEEN_SPAWNS = 1;
    const float DECREASE_SPAWN_TIME = 1.5f;

    private void Start()
    {
        timeBetweenSpawns = startTimeBetweenSpawns;
        spawnTimeDecreaseTime += Time.time;
        startTimeBetweenSpawns += Time.time;
        startDelay += Time.time;
    }

    void Update()
    {
        if (GameManager.Instance.gameState != "play")
        {
            return;
        }

        print(startTimeBetweenSpawns);
        if (Time.time < startDelay)
        {
            return;
        }

        if (Time.time >= spawnTimeDecreaseTime && timeBetweenSpawns > MIN_TIME_BETWEEN_SPAWNS)
        {
            timeBetweenSpawns /= DECREASE_SPAWN_TIME;
        }

        if (Time.time >= nextSpawnTime)
        {
            Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
