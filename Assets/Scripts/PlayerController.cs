using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 5f;
    private float inputHorizontal;
    private float inputVertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * inputVertical);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * inputHorizontal);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * inputHorizontal);
    }
}
