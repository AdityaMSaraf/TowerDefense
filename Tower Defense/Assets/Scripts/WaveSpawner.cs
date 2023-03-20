using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float timeBwWaves = 5f;
    private float countDown = 2f;
    private int waveNum = 0;
    public Transform spawnPoint;
    public TextMeshProUGUI waveText;
    private void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBwWaves;
        }

        countDown -= Time.deltaTime;

        waveText.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNum++;
        for (int i = 0; i < waveNum-1; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
