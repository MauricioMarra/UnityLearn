using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public float speed;
    public Prototype3.PlayerController playerController;
    
    private float originalX;
    private Vector2 backgroundSize;

    // Start is called before the first frame update
    void Start()
    {
        backgroundSize = GetComponent<SpriteRenderer>().size;
        originalX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.gameOver)
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= originalX - backgroundSize.x/2)
            this.transform.position = new Vector3(originalX, 9.5f, 4f);
    }
}
