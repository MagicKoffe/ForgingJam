using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Transform playerReticle;
    Vector3 aimDirection;
    public GameObject wpnUI;
    public WeaponTemplate[] weaponArray;
    PlayerBuilding playerBuilding;
    public WeaponTemplate currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        playerReticle = GameObject.FindGameObjectWithTag("Reticle").GetComponent<Transform>();
        playerBuilding = GetComponent<PlayerBuilding>();
    }

    // Update is called once per frame
    void Update()
    {
        checkBuilding();
        getAimDirection();

        if (Input.GetKeyDown(KeyCode.Mouse0) && !playerBuilding.buildMode)
        {
            shootWeapon();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = weaponArray[0];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = weaponArray[1];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = weaponArray[2];
        }
    }

    private void checkBuilding()
    {
        if (playerBuilding.buildMode)
        {
            wpnUI.SetActive(false);
        }
        else
        {
            wpnUI.SetActive(true);
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
        aimDirection.y = 0;
        Debug.DrawLine(transform.position, aimDirection * 300);
    }
}
