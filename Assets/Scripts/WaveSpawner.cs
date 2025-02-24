﻿using UnityEngine;
using System.Collections;
using TMPro;

public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public GameManager gameManager;

    public Wave[] waves;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timeBetweenWaves = 5f;

    private float countdown = 5f;

    [SerializeField]
    private TextMeshProUGUI waveCountdownTimer;

    [SerializeField]
    private TextMeshProUGUI WaveCount;

    private int waveIndex = 0;

    private void Start()
    {
        EnemiesAlive = 0;
    }

    void Update () {

        if(EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownTimer.text = "Prochaine vague : " + string.Format("{00:0.0}", countdown);

	}

    IEnumerator SpawnWave()
    {
        
        PlayerStats.rounds++;
        WaveCount.text = "Vague " + PlayerStats.rounds.ToString();

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}