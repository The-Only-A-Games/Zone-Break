using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRange = 10f;

    void Start()
    {
        SpawnRandomObject();
    }

    void SpawnRandomObject()
    {
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(randomX, -0.45f, randomZ);

        // Spawn the object
        Instantiate(objectToSpawn, randomPos, Quaternion.identity);
    }
}
