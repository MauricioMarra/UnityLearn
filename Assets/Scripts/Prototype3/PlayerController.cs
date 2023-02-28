using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype3
{
    public class PlayerController : MonoBehaviour
    {
        public float jumpForce;
        public float gravityModifier;
        public bool gameOver = false;

        private Rigidbody playerRigidBody;
        private bool isOnGround = true;
        private string groundTag = "Ground";
        private string obstacleTag = "Obstacle";

        // Start is called before the first frame update
        void Start()
        {
            playerRigidBody = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
            }

            Debug.Log(gameOver);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(groundTag))
                isOnGround = true;
            else if (collision.gameObject.CompareTag(obstacleTag))
                gameOver = true;
        }
    }
}

