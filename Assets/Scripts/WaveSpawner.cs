using UnityEngine;
using System.Collections;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
public Wave[] waves;

public GameManager gameManager;

[SerializeField]  private float timeBetweenWaves = 6f;

[SerializeField] private Transform spawnPoint;

[SerializeField] private TextMeshProUGUI waveCountdownTimer;

private float countdown;
public static int EnemiesAlive = 0;
private int waveIndex = 0;

    void Start(){
        countdown = 5f;
    }
    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
          if(waveIndex == waves.Length){
            gameManager.WinLevel();
            this.enabled = false;
        };

        if(countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave(){
     PlayerStats.rounds++;

     Wave wave = waves[waveIndex];
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
         waveIndex++;
        
     
    }
    
    void SpawnEnemy(GameObject enemy){
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
