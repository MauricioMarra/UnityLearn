using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rigidBody;
    
    private float xRange = 4;
    private float torque = 10f;
    private float zDestroyValue = -10;
    private float minForceUp = 12f;
    private float maxForceUp = 18f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        rigidBody.AddForce(RandomForce(), ForceMode.Impulse);
        rigidBody.AddTorque(RandomTorque(), ForceMode.Impulse);

        transform.position = RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < zDestroyValue)
            Destroy(gameObject);
    }

    Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(-torque, torque), Random.Range(-torque, torque), Random.Range(-torque, torque));
    }

    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), -6);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForceUp, maxForceUp);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
