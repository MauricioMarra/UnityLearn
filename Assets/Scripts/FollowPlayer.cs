using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new(0, 5, -7);
    private Vector3 offsetHood = new(0, 2.25f, 1.40f);
    private Vector3 currentOffset = new(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        currentOffset = offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + currentOffset;

        if (Input.GetKeyDown(KeyCode.C))
            ChangeView();
    }

    void ChangeView()
    {
        if (currentOffset == offset)
            currentOffset = offsetHood;
        else
            currentOffset = offset;
    }
}
