using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundEnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyPrefabInfo
    {
        public GameObject prefab;
        public float weight = 1f;
    }

    public List<EnemyPrefabInfo> backgroundEnemyPrefabs;
    public List<Transform> spawnPoints;
    public List<Transform> exitPoints;
    
    public float minSpawnInterval = 5f;
    public float maxSpawnInterval = 15f;
    
    public float minEnemySpeed = 1f;
    public float maxEnemySpeed = 3f;

    private float totalWeight;

    private void Start()
    {
        CalculateTotalWeight();
        StartCoroutine(SpawnBackgroundEnemies());
    }

    private void CalculateTotalWeight()
    {
        totalWeight = 0f;
        foreach (var enemyInfo in backgroundEnemyPrefabs)
        {
            totalWeight += enemyInfo.weight;
        }
    }

    private IEnumerator SpawnBackgroundEnemies()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);
            
            SpawnBackgroundEnemy();
        }
    }

    private void SpawnBackgroundEnemy()
    {
        int startIndex = Random.Range(0, spawnPoints.Count);
        int endIndex = Random.Range(0, exitPoints.Count);

        Vector3 startPos = spawnPoints[startIndex].position;
        Vector3 endPos = exitPoints[endIndex].position;

        GameObject enemyPrefab = ChooseRandomEnemyPrefab();
        GameObject enemy = Instantiate(enemyPrefab, startPos, Quaternion.identity);
        
        float enemySpeed = Random.Range(minEnemySpeed, maxEnemySpeed);
        StartCoroutine(MoveEnemy(enemy, startPos, endPos, enemySpeed));
    }

    private GameObject ChooseRandomEnemyPrefab()
    {
        float randomValue = Random.Range(0f, totalWeight);
        float currentWeight = 0f;

        foreach (var enemyInfo in backgroundEnemyPrefabs)
        {
            currentWeight += enemyInfo.weight;
            if (randomValue <= currentWeight)
            {
                return enemyInfo.prefab;
            }
        }

        return backgroundEnemyPrefabs[backgroundEnemyPrefabs.Count - 1].prefab;
    }

    private IEnumerator MoveEnemy(GameObject enemy, Vector3 startPos, Vector3 endPos, float speed)
    {
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        while (enemy != null)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;
            
            if (fractionOfJourney >= 1)
            {
                Destroy(enemy);
                yield break;
            }

            enemy.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }
    }
}