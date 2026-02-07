using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject trashPrefab; // Drag your Trash Prefab here
    public float spawnRate = 2f;   // How many seconds between spawns
    public float spawnXRange = 3f; // Width of the spawn area (for your vertical screen)
    public float spawnYPos = 6f;   // Height to spawn at (above the camera)

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnTrash();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnTrash()
    {
        // Pick a random X position within your vertical screen limits
        float randomX = Random.Range(-spawnXRange, spawnXRange);
        Vector3 spawnPos = new Vector3(randomX, spawnYPos, 0);

        // Create the trash!
        Instantiate(trashPrefab, spawnPos, Quaternion.identity);
    }
}