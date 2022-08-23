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

    public GameObject bossPrefab;
    public GameObject[] miniEnemyPrefabs;
    public int bossRound;

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
        if (enemyCount == 0)
        {
            waveNumber++;
            //Spawn a boss every x number of waves
            if (waveNumber % bossRound == 0)
            {
                SpawnBossWave(waveNumber);
            }
            else
            {
                SpawnEnemyWave(waveNumber);
            }
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

    void SpawnBossWave(int currentRound)
    {
        int miniEnemysToSpawn;
        // prevent zero devision
        miniEnemysToSpawn = (bossRound == 0) ? 1 : (currentRound / bossRound);
        var boss = Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
        boss.GetComponent<Enemy>().miniEnemySpawnCount = miniEnemysToSpawn;
    }

    public void SpawnMiniEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomMini = Random.Range(0, miniEnemyPrefabs.Length);
            Instantiate(miniEnemyPrefabs[randomMini], GenerateSpawnPosition(), miniEnemyPrefabs[randomMini].transform.rotation);
        }
    }
}
