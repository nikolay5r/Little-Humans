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

    private void Start()
    {
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Vector3 pos = spawnPoint.position;
            pos.z = workerPrefab.transform.position.z;
            Instantiate(workerPrefab, pos, Quaternion.identity);
            numberOfWorkersToSpawn--;
        }

        if (numberOfWorkersToSpawn <= 0)
        {
            Destroy(gameObject);
        }
    }
}
