using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 30f;
    private float inputHorizontal;
    private float inputVertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal2");
        inputVertical = Input.GetAxis("Vertical2");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * inputVertical);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * inputHorizontal);
    }
}
