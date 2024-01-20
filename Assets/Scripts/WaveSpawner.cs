using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public static int enemiesAlive = 0;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float timeBetweenWaves = 5f;
    private float countdown = 2.5f; // time before spawning the first wave
    [SerializeField] TMP_Text waveCountdownText;

    private void Start()
    {
        StartCoroutine(SpawnWavesForever());
    }

    IEnumerator SpawnWavesForever()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnWave());
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.roundsSurvived++;
        waveCountdownText.text = Convert.ToString(PlayerStats.roundsSurvived);
        Wave wave = GetRandomWave();

        int numberOfEnemies = UnityEngine.Random.Range(wave.minNumberOfEnemies, wave.maxNumberOfEnemies + 1);

        for (int i = 0; i < numberOfEnemies; i++)
        {            
            GameObject randomEnemy = wave.GetRandomEnemy();
            SpawnEnemy(randomEnemy);

            float timeDelay = 0.2f / wave.spawnRate; // Decreased time delay for faster spawning
            float additionalDelay = 0.1f; // Decreased additional delay

            yield return new WaitForSeconds(timeDelay + (additionalDelay * i));
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        enemiesAlive++;
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    private Wave GetRandomWave()
    {
        int randomIndex = UnityEngine.Random.Range(0, waves.Length);
        return waves[randomIndex];
    }
}