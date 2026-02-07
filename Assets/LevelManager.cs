using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject trashPrefab;
    public float spawnRate = 2f;
    public float spawnXRange = 2.3f; // Adjusted for your vertical screen
    public float spawnYPos = 6f;

    [Header("Difficulty Levels")]
    public int currentLevel = 1;
    public float levelDuration = 20f; // Seconds until next level
    private float levelTimer;

    private float nextSpawnTime;

    void Update()
    {
        // 1. Handle Leveling Up
        levelTimer += Time.deltaTime;
        if (levelTimer >= levelDuration && currentLevel < 3)
        {
            currentLevel++;
            levelTimer = 0;
            Debug.Log("Level Up! Current Level: " + currentLevel);
        }

        // 2. Handle Double Spawning
        if (Time.time >= nextSpawnTime)
        {
            SpawnTrashPair();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnTrashPair()
    {
        // Spawn two pieces at once
        for (int i = 0; i < 2; i++)
        {
            float randomX = Random.Range(-spawnXRange, spawnXRange);
            Vector3 spawnPos = new Vector3(randomX, spawnYPos, 0);
            
            GameObject newTrash = Instantiate(trashPrefab, spawnPos, Quaternion.identity);
            TrashEnemy script = newTrash.GetComponent<TrashEnemy>();

            // Assign random speed based on current level
            script.fallSpeed = GetRandomSpeedForLevel();
        }
    }

    float GetRandomSpeedForLevel()
    {
        // Level 1: 3 to 5 | Level 2: 5 to 7 | Level 3: 7 to 10
        switch (currentLevel)
        {
            case 1: return Random.Range(3f, 5f);
            case 2: return Random.Range(5f, 7f);
            case 3: return Random.Range(7f, 10f);
            default: return 5f;
        }
    }
}