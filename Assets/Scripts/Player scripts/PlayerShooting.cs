using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Transform playerReticle;
    Vector3 aimDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerReticle = GameObject.FindGameObjectWithTag("Reticle").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        getAimDirection();
    }

    //Calculate aim direction by subtracting reticel position - player position
    private void getAimDirection()
    {
        aimDirection = (playerReticle.position - transform.position).normalized;
        Debug.DrawLine(transform.position, aimDirection * 300);
    }
}
