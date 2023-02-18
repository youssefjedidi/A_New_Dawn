using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // An array of obstacle prefabs to randomly choose from
    public Transform[] spawnPoints; // An array of spawn points to randomly choose from
    public float minSpawnDelay = 1.0f; // Minimum delay between obstacle spawns
    public float maxSpawnDelay = 3.0f; // Maximum delay between obstacle spawns

    private float currentSpawnDelay;

    private void Start()
    {
        currentSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
    }

    private void Update()
    {
        currentSpawnDelay -= Time.deltaTime;

        if (currentSpawnDelay <= 0.0f)
        {
            // Choose a random obstacle prefab and spawn point
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            GameObject obstacle = obstaclePrefabs[obstacleIndex];
            Transform spawnPoint = spawnPoints[spawnPointIndex];

            // Instantiate the obstacle at the chosen spawn point
            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);

            // Reset the spawn delay to a new random value
            currentSpawnDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        }
    }
}
