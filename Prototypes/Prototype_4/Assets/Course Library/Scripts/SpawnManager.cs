using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spwanRange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {
        float spawnPositonX = Random.Range(-spwanRange, spwanRange);
        float spawnPositonZ = Random.Range(-spwanRange, spwanRange);

        Vector3 ramdomPos = new Vector3(spawnPositonX, 0, spawnPositonZ);

        Instantiate(enemyPrefab, ramdomPos, enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
