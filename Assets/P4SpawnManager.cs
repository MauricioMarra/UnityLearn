using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPrefab;
    [SerializeField]
    private float delay;

    private float spawnRange = 9f;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        Instantiate(spawnPrefab, GenerateRandomSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GenerateRandomSpawnPosition()
    {
        var x = Random.Range(-spawnRange, spawnRange);
        var z = Random.Range(-spawnRange, spawnRange);

        var position = new Vector3(x, 0, z);

        return position;
    }
}
