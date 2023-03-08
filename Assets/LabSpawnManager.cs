using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabSpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnList;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnCitizen), 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCitizen()
    {
        int i = Random.Range(0, spawnList.Count);
        Instantiate(spawnList[i], transform.position, Quaternion.LookRotation(Vector3.forward * -1));
    }
}
