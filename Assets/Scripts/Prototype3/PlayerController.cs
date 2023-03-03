using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        private bool hasGameStarted = false;

        private int jumpsLeft = 2;
        private int dashMultiplier = 1;
        
        private float score = 0;
        
        private string groundTag = "Ground";
        private string obstacleTag = "Obstacle";
        private string animatorSpeed_f = "Speed_f";
        private string animatorJump_trig = "Jump_trig";
        private string animatorDeath_b = "Death_b";
        private string animatorDeathTypeInt = "DeathType_int";

        private Vector3 startingPosition;
        
        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            playerRigidBody = GetComponent<Rigidbody>();
            Physics.gravity *= gravityModifier;

            animator = GetComponent<Animator>();

            gameOver = true;
            StartCoroutine(nameof(PlayIntroCoroutine));
        }

        // Update is called once per frame
        void Update()
        {
            if (hasGameStarted)
            {
                Jump();

                Dash();

                if (gameOver)
                {
                    animator.SetBool(animatorDeath_b, true);
                    animator.SetInteger(animatorDeathTypeInt, 1);
                }
                else
                    animator.SetFloat(animatorSpeed_f, 10);
            
                score += Time.deltaTime * dashMultiplier;
                Debug.Log(score);
            }
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !gameOver && jumpsLeft > 0)
            {
                isOnGround = false;
                jumpsLeft--;
                playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                animator.SetTrigger(animatorJump_trig);
                psDirt.Stop();
                playerAudioSource.PlayOneShot(jumpSound);
            }

            if (transform.position.y > 6)
                transform.position = new Vector3(transform.position.x, 6, transform.position.z);
        }

        private void Dash()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.speed = 2;
                dashMultiplier = 2;
            }
            else
            {
                animator.speed = 1;
                dashMultiplier = 1;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(groundTag))
            {
                isOnGround = true;
                jumpsLeft = 2;
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

        public int GetDashMultiplier()
        {
            return dashMultiplier;
        }

        IEnumerator PlayIntroCoroutine()
        {
            Vector3 startPos = new Vector3(-8, transform.position.y, transform.position.z);
            Vector3 endPos = transform.position;

            float lerpSpeed = 5f;
            float journeyLength = Vector3.Distance(startPos, endPos);
            float startTime = Time.time;
            float distanceCovered = (Time.time - startTime) * lerpSpeed; //Velocidade * Tempo = Distância percorrida (aceleração constante)
            float fractionOfJourney = distanceCovered / journeyLength;
            
            animator.SetFloat(animatorSpeed_f, 0.5f);

            while (fractionOfJourney < 1)
            {
                //distanceCovered = (Time.time - startTime) * lerpSpeed;
                //fractionOfJourney = distanceCovered / journeyLength;
                //transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
                //yield return null;

                distanceCovered = (Time.time) * lerpSpeed;
                fractionOfJourney = distanceCovered / journeyLength;
                transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
                yield return null;
            }
            animator.SetFloat(animatorSpeed_f, 10f);
            gameOver = false;
            hasGameStarted = true;
        }
    }
}

