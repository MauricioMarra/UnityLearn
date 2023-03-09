using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimController : MonoBehaviour
{
    private Animator victimAnimator;

    // Start is called before the first frame update
    void Start()
    {
        victimAnimator = GetComponent<Animator>();

        victimAnimator.SetBool("Death_b", true);
        victimAnimator.SetInteger("DeathType_int", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
