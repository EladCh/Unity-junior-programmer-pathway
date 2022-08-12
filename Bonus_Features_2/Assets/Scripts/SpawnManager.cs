using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRange = 20.0f;
    private float spawnPosZ = 20.0f;
    private float startDelay = 1.0f;
    private float spawnInterval = 1.5f;

    public float sideSpawnMinZ = 0.0f;
    public float sideSpawnMaxZ = 15.0f;
    public float sideSpawnX = -18.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnLeftAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnRightAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal() {
        // Randomly generate animal index and spwan position
        int animalIdx = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIdx], spawnPos, animalPrefabs[animalIdx].transform.rotation);
    }

    void SpawnLeftAnimal()
    {
        // Randomly generate animal index and spwan position
        int animalIdx = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(-sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, 90, 0);
        Instantiate(animalPrefabs[animalIdx], spawnPos, Quaternion.Euler(rotation));
    }

    void SpawnRightAnimal()
    {
        // Randomly generate animal index and spwan position
        int animalIdx = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(sideSpawnX, 0, Random.Range(sideSpawnMinZ, sideSpawnMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);
        Instantiate(animalPrefabs[animalIdx], spawnPos, Quaternion.Euler(rotation));
    }
}
