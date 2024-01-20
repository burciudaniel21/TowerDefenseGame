using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject[] enemies;
    public float spawnRate;
    public int minNumberOfEnemies; // Added minimum number of enemies
    public int maxNumberOfEnemies;

    public GameObject GetRandomEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Length);
        return enemies[randomIndex];
    }
}