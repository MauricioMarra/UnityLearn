using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabPlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody playerRb;
    private Animator playerAnimator;

    private float horizontalInput;
    private float verticalInput;
    private float rightLeftBounds = 8.5f;

    private Vector3 direction = new();

    private string animatorSpeed_f = "Speed_f";

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        ConstrainPlayer();
    }

    private void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        direction = new(horizontalInput * speed, 0, verticalInput * speed);
        playerRb.MovePosition(playerRb.position + direction * Time.deltaTime);

        if (direction.magnitude > 0.9f)
            playerAnimator.SetFloat(animatorSpeed_f, direction.magnitude);
        else
            playerAnimator.SetFloat(animatorSpeed_f, 0);

    }

    private void ConstrainPlayer()
    {
        if (playerRb.position.x < -rightLeftBounds)
            playerRb.position = new Vector3(-rightLeftBounds, 0, playerRb.position.z);
        else if (playerRb.position.x > rightLeftBounds)
            playerRb.position = new Vector3(rightLeftBounds, 0, playerRb.position.z);
    }
}
