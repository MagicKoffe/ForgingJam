using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Transform playerReticle;
    Vector3 aimDirection;

    public WeaponTemplate currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        playerReticle = GameObject.FindGameObjectWithTag("Reticle").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        getAimDirection();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shootWeapon();
        }
    }

    private void shootWeapon()
    {
        currentWeapon.shoot(transform, aimDirection, playerReticle);
    }

    //Calculate aim direction by subtracting reticel position - player position
    private void getAimDirection()
    {
        aimDirection = (playerReticle.position - transform.position).normalized;
        Debug.DrawLine(transform.position, aimDirection * 300);
    }
}
