using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed;

    private Rigidbody enemyRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var target = (player.transform.position - transform.position).normalized;
        enemyRigidBody.AddForce(target * speed);
    }
}
