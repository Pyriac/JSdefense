using UnityEngine;
using System.Collections;
using TMPro;
public class WaveSpawner : MonoBehaviour
{
[SerializeField] private Transform enemyPrefab;

[SerializeField]  private float timeBetweenWaves = 6f;

[SerializeField] private Transform spawnPoint;

[SerializeField] private TextMeshProUGUI waveCountdownTimer;

private float countdown = 5f;

private int waveIndex = 0;
    void Update()
    {
        if(countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave(){
     waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }
    
    void SpawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
