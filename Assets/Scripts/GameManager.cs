using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRange = 10f;


    public GameObject enemyPrefab;  // assign your enemy prefab in inspector
    public float spawnRadius = 20f; // how far from spawner enemies can appear
    public int enemiesPerWave = 5;  // how many enemies to spawn

    void Start()
    {
        // SpawnRandomObject();
    }

    void SpawnRandomObject()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Vector3 spawnPos = GetRandomPointOnNavMesh(transform.position, spawnRadius);
            Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
        }
    }

    public static Vector3 GetRandomPointOnNavMesh(Vector3 center, float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += center;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return center;
    }
}
