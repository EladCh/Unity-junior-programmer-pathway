using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRange = 20.0f;
    private float spawnPosZ = 20.0f;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
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
}
