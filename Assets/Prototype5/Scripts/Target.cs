using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    private Rigidbody rigidBody;
    private GameManager gameManager;

    [SerializeField] private ParticleSystem explosion;

    [SerializeField] private int pointValue;

    private float xRange = 4;
    private float torque = 10f;
    private float zDestroyValue = -3;
    private float minForceUp = 12f;
    private float maxForceUp = 16f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        rigidBody = GetComponent<Rigidbody>();

        rigidBody.AddForce(RandomForce(), ForceMode.Impulse);
        rigidBody.AddTorque(RandomTorque(), ForceMode.Impulse);

        transform.position = RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= zDestroyValue)
        {
            if (!transform.CompareTag("Bad"))
            {
                gameManager.GameOver();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(-torque, torque), Random.Range(-torque, torque), Random.Range(-torque, torque));
    }

    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), -0.8f);
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForceUp, maxForceUp);
    }

    //private void OnMouseDown()
    //{
    //    if (gameManager.isGameActive)
    //    {
    //        Destroy(gameObject);
    //        Instantiate(explosion, transform.position, Quaternion.identity);
    //        gameManager.UpdateScore(pointValue);
    //    }
    //}

    public void DestroyObject()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameManager.UpdateScore(pointValue);
        }
    }
}
