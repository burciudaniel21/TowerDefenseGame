using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] Transform spawnPoint;
    [SerializeField] Transform enemyPrefab;
    [SerializeField] float timeBetweenWaves = 5f;
    private float countdown = 2.5f; //time before spawning first wave
    private int waveIndex = 0;
    [SerializeField] TMP_Text waveCountdownText;

    private void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f); //add a delay to the spawner using Coroutine
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
