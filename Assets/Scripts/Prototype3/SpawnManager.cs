using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnDelay;
    
    private Vector3 spawnPosition = new(30, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateObstacle", spawnDelay, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateObstacle()
    {
        Instantiate(objectToSpawn, spawnPosition, objectToSpawn.transform.rotation);
    }
}
