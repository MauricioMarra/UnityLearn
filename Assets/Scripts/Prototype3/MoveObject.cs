using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed;

    private Prototype3.PlayerController playerController;
    private string obstacleTag = "Obstacle";
    private float bounds = -15f;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<Prototype3.PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.gameOver)
            transform.Translate(Vector3.left * speed * Time.deltaTime * playerController.GetDashMultiplier());

        if (transform.position.x < bounds && this.CompareTag(obstacleTag))
        {
            Destroy(gameObject);
        }
    }
}
