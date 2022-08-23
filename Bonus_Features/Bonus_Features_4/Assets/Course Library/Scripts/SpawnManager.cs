using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spwanRange = 9.0f;
    public GameObject[] enemyPrefabs;
    public GameObject[] powerupPrefabs;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            // spawn random enemies
            int randomIdx = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomIdx], GenerateSpawnPosition(), enemyPrefabs[randomIdx].transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        // spawn random enemies
        int randomIdx = Random.Range(0, powerupPrefabs.Length);
        Instantiate(powerupPrefabs[randomIdx], GenerateSpawnPosition(), powerupPrefabs[randomIdx].transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositonX = Random.Range(-spwanRange, spwanRange);
        float spawnPositonZ = Random.Range(-spwanRange, spwanRange);

        Vector3 ramdomPos = new Vector3(spawnPositonX, 0, spawnPositonZ);
        
        return ramdomPos;
    }
}
