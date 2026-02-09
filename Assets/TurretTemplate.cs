using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTemplate : MonoBehaviour
{
    public Transform shootingPoint;
    Vector3 aimDirection;
    public Transform currentTarget;
    float closestDistance;
    GameObject[] allEnemies;
    public float maxHealth;
    float currentHealth;
    public float range;

    BuildScriptableObject turretStats;

    public void passScriptableObject(BuildScriptableObject _stats)
    {
        turretStats = _stats;
        maxHealth = _stats.health;
        range = _stats.range;
        currentHealth = maxHealth;
        InvokeRepeating("shootTarget", turretStats.fireRate, turretStats.fireRate);
    }

    private void Update()
    {
        calculateTargets();
        getAimDirection();
    }

    private void calculateTargets()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (currentTarget == null)
        {
            if (allEnemies[0] == null)
                return;

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

    private void getAimDirection()
    {
        aimDirection = (currentTarget.position - transform.position).normalized;
    }

    public void shootTarget()
    {
        if (currentTarget == null)
            return;

        if(closestDistance <= range)
        {
            if (turretStats.tracking)
            {
                GameObject _projectile = Instantiate(turretStats.projectile, shootingPoint.position, Quaternion.identity);
                _projectile.GetComponent<turretProjectile>().setStats(turretStats.damage, turretStats.projectileLifeTime);
                _projectile.GetComponent<turretProjectile>().arcTowardsTarget(shootingPoint.position, currentTarget, turretStats.projectileSpeed);
            }
            else
            {

                GameObject _projectile = Instantiate(turretStats.projectile, shootingPoint.position, Quaternion.identity);

                Rigidbody projectileRB = _projectile.GetComponent<Rigidbody>();
                _projectile.GetComponent<turretProjectile>().setStats(turretStats.damage, turretStats.projectileLifeTime);

                projectileRB.AddForce(turretStats.projectileSpeed * aimDirection * 10, ForceMode.Acceleration);
            }
        }
    }
}
