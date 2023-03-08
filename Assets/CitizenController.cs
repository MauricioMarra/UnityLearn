using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 knockbackForce;

    private Animator citizenAnimator;

    // Start is called before the first frame update
    void Start()
    {
        citizenAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        citizenAnimator.SetFloat("Speed_f", 1);

        if (transform.position.z < player.transform.position.z - 2f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(knockbackForce * Time.deltaTime);
        }
    }
}
