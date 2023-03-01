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
        public ParticleSystem psExplosion;
        public ParticleSystem psDirt;
        public AudioClip jumpSound;
        public AudioClip crashSound;
        public AudioSource playerAudioSource;

        private Rigidbody playerRigidBody;
        private bool isOnGround = true;
        private string groundTag = "Ground";
        private string obstacleTag = "Obstacle";
        private Animator animator;
        private string animatorSpeed_f = "Speed_f";
        private string animatorJump_trig = "Jump_trig";
        private string animatorDeath_b = "Death_b";
        private string animatorDeathTypeInt = "DeathType_int";

        // Start is called before the first frame update
        void Start()
        {
            playerRigidBody = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;

            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
            {
                playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                animator.SetTrigger(animatorJump_trig);
                psDirt.Stop();
                playerAudioSource.PlayOneShot(jumpSound);
            }

            if (gameOver)
            {
                animator.SetBool(animatorDeath_b, true);
                animator.SetInteger(animatorDeathTypeInt, 1);
            }
            else
                animator.SetFloat(animatorSpeed_f, 10);


            Debug.Log(gameOver);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(groundTag))
            {
                isOnGround = true;
                psDirt.Play();
            }
            else if (collision.gameObject.CompareTag(obstacleTag))
            {
                gameOver = true;
                if (psExplosion != null)
                    psExplosion.Play();

                psDirt.Stop();

                playerAudioSource.PlayOneShot(crashSound);
            }
        }
    }
}

