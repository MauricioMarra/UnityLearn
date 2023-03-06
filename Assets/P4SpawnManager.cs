using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private GameObject spawnPowerUp;
    [SerializeField]
    private float delay;

    private int waveCount = 0;

    private float spawnRange = 9f;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var enemyCount = GameObject.FindObjectsOfType<EnemyControl>().Length;

        if (enemyCount == 0)
        {
            waveCount++;
            SpawnObject(waveCount);
        }
    }

    void SpawnObject(int number = 1)
    {
        for(int i = 0; i < number; i++)
        {
            Instantiate(spawnPrefab, GenerateRandomSpawnPosition(), Quaternion.identity);
        }

        Instantiate(spawnPowerUp, GenerateRandomSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        var x = Random.Range(-spawnRange, spawnRange);
        var z = Random.Range(-spawnRange, spawnRange);

        var position = new Vector3(x, 0, z);

        return position;
    }
}
