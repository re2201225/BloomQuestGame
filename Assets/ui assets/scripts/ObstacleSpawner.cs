using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Prefab & Spawn Settings")]
    public GameObject obstaclePrefab;      // drag your Obstacle prefab here
    public Transform spawnPoint;          // drag the empty child Transform here
    public float spawnInterval = 2f;      // seconds between spawns

    float _nextSpawnTime;

    void Update()
    {
        // time to spawn?
        if (Time.time >= _nextSpawnTime)
        {
            SpawnObstacle();
            _nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
