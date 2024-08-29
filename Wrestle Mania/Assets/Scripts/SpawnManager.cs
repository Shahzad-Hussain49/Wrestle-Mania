using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] float spawnRange = 9.0f;

    private int enemyCount = 0;
    private int waveNumber = 1;
    private void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerUp();
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUp();
        }
    }
    void SpawnEnemyWave(int enemiesToSpawn) 
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
         Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
    
    }

    void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, GenerateRandomPosition(),powerUpPrefab.transform.rotation);
    }


    private Vector3 GenerateRandomPosition()
    {

        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 enemyPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return enemyPos;
    }
}
