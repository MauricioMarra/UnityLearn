using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]
public class ClickAndSwipe : MonoBehaviour
{
    GameManager gameManager;
    Camera camera;
    Collider collider;
    TrailRenderer trailRenderer;
    Vector3 mousePosition;

    bool isSwiping = false;

    // Start is called before the first frame update
    void Awake()
    {
        camera = Camera.main;
        collider = GetComponent<Collider>();
        trailRenderer = GetComponent<TrailRenderer>();

        collider.enabled = false;
        trailRenderer.enabled = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.position = mousePosition;
            mousePosition = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

            if (Input.GetMouseButtonDown(0))
            {
                isSwiping = true;
                UpdateComponents();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isSwiping = false;
                UpdateComponents();
            }
        }
    }

    void UpdateComponents()
    {
        trailRenderer.enabled = isSwiping;
        collider.enabled = isSwiping;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var type = collision.gameObject.GetComponent<Target>();

        if (type != null)
        {
            type.DestroyObject();
        }
    }
}
