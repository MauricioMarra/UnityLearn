using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField]
    private float speed = 200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = Input.GetAxis("Mouse X");
        transform.Rotate(transform.rotation.x, direction * speed * Time.deltaTime, transform.rotation.z);
    }
}
