using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float bounceForce = 1.0f;
    public AudioClip bounceSound;
    public AudioSource bounceSource;

    private void OnCollisionEnter(Collision collision)
    {
        var rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
            rb.AddForce(new Vector3(0, bounceForce, 0), ForceMode.Impulse);

        if (bounceSound != null)
            bounceSource.PlayOneShot(bounceSound);
    }
}
