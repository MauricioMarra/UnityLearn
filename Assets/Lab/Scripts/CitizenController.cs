using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 knockbackDirection;
    [SerializeField] private float knockbackSpeed;

    private Animator citizenAnimator;

    // Start is called before the first frame update
    void Start()
    {
        citizenAnimator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        speed = Random.Range(5f, 10f);
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
            rb.AddForce(knockbackDirection * knockbackSpeed, ForceMode.Impulse);
        }
    }
}
