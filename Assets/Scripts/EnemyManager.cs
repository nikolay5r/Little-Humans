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
            timeBetweenSpawns--;
        }

        if (Time.time >= nextSpawnTime)
        {
            Vector3 pos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            pos.z = enemyPrefab.transform.position.z;
            Instantiate(enemyPrefab, pos, Quaternion.identity);
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }
}
