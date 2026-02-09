using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTemplate : MonoBehaviour
{
    Transform currentTarget;
    float closestDistance;
    GameObject[] allEnemies;
    public float damage;
    public float maxHealth;
    float currentHealth;
    public float range;

    public float fireRate;
    public float projectileSpeed;
    public float projectileLifeTime;
    public bool tracking;
    public GameObject projectile;

    private void Start()
    {
        currentHealth = maxHealth;
        InvokeRepeating("shootTarget", fireRate, fireRate);
    }

    private void Update()
    {
        calculateTargets();
    }

    private void calculateTargets()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (currentTarget == null)
        {
            currentTarget = allEnemies[0].GetComponent<Transform>();
            closestDistance = Vector3.Distance(currentTarget.position, transform.position);
        }

        for (int i = 0; i < allEnemies.Length; i++)
        {
            Transform tempTarget = allEnemies[i].GetComponent<Transform>();
            float checkDistance = Vector3.Distance(tempTarget.position, transform.position);

            if(checkDistance < closestDistance)
            {
                currentTarget = tempTarget;
                closestDistance = checkDistance;
            }
        }

        
    }

    public void shootTarget()
    {
        if(closestDistance <= range)
        {
            //Shoot projectile
        }
    }
}
