using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class P4PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 50f;
    [SerializeField]
    private Transform focalPoint;
    [SerializeField]
    private float knockbackStrenght;
    [SerializeField]
    private bool hasPowerUp = false;
    [SerializeField]
    private GameObject powerUpIndicator;

    private string tagPowerUp = "PowerUp";
    private string tagEnemy = "Enemy";

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

        powerUpIndicator.transform.position = playerRigidBody.transform.position + new Vector3(0, -0.6f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagPowerUp))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(nameof(PowerUpDisableCountDown));
            powerUpIndicator.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagEnemy) && hasPowerUp)
        {
            var knockbackDirection = collision.gameObject.transform.position - transform.position;

            var rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddForce(knockbackDirection * knockbackStrenght, ForceMode.Impulse);

            Debug.Log(rb);
        }
    }

    IEnumerator PowerUpDisableCountDown()
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }
}
