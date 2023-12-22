using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public static int enemiesAlive = 0;
    [SerializeField] Transform spawnPoint;
    //[SerializeField] Transform enemyPrefab;
    [SerializeField] float timeBetweenWaves = 5f;
    private float countdown = 2.5f; //time before spawning first wave
    private int waveIndex = 0;
    [SerializeField] TMP_Text waveCountdownText;

    private void Update()
    {
        if(enemiesAlive > 0)
        {
            return;
        }

        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity) ; //ensure countdown is never less than 0

        string formattedCountdown = countdown.ToString("0.00"); //format numbers for displaying on the UI
        waveCountdownText.text = formattedCountdown; //update on the UI
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.roundsSurvived++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            // Calculate the delay between spawns with an additional time delay
            float timeDelay = 2f / wave.spawnRate; // Base delay based on spawn rate
            float additionalDelay = 1.5f; // Additional delay between each spawn

            yield return new WaitForSeconds(timeDelay + (additionalDelay * i));
        }

        waveIndex++;
        if (waveIndex >= waves.Length && wave.count == 1)
        {
            Debug.Log("You won :)");
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        enemiesAlive++;
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
