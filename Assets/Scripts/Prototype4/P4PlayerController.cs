using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 50f;
    [SerializeField]
    private Transform focalPoint;

    private Rigidbody playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        var direction = Input.GetAxis("Vertical2");
        playerRigidBody.AddForce(focalPoint.transform.forward * speed * direction * Time.deltaTime);
    }
}
