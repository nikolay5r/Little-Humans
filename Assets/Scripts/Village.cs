using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    public GameObject workerPrefab;
    public Transform spawnPoint;
    public float timeBetweenSpawns;
    float nextSpawnTime;
    public float numberOfWorkersToSpawn;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Instantiate(workerPrefab, spawnPoint.position, Quaternion.identity);
            numberOfWorkersToSpawn--;
        }

        if (numberOfWorkersToSpawn <= 0)
        {
            Destroy(gameObject);
        }
    }
}
