using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform currentTarget;

    Transform player;
    public GameObject[] islands;
    GameObject[] turrets;
    Vector3 aimDirection;

    Transform turretTarget;
    Transform islandTarget;
    float playerDistance;
    float nearestIslandDistance;
    float nearestTurretDistance;

    public GameObject enemyProjectile;
    public float projectileSpeed;
    public float damage;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        islands = GameObject.FindGameObjectsWithTag("IslandBase");
        InvokeRepeating("shootTarget", 5f, 5f);

        nearestIslandDistance = 99999999999999999999999999999999999f;
        playerDistance = 99999999999999999999999999999999999f;
        nearestTurretDistance = 99999999999999999999999999999999999f;

        currentTarget = player;
    }

    // Update is called once per frame
    void Update()
    {
        updateTarget();
        getAimDirection();
    }

    private void updateTarget()
    {

        turrets = GameObject.FindGameObjectsWithTag("Turret");

        Debug.Log("Checking targets");

        if (currentTarget == null)
        {
            nearestIslandDistance = 99999999999999999999999999999999999f;
            playerDistance = 99999999999999999999999999999999999f;
            nearestTurretDistance = 99999999999999999999999999999999999f;

            if (islands.Length == 0)
                return;

            currentTarget = player;
            //nearestIslandDistance = Vector3.Distance(currentTarget.position, transform.position);
        }

        for (int i = 0; i < islands.Length; i++)
        {
            if(islands[i] != null)
            {
                Transform tempTarget = islands[i].GetComponent<Transform>();
                float checkDistance = Vector3.Distance(tempTarget.position, transform.position);

                if (checkDistance < nearestIslandDistance)
                {
                    islandTarget = tempTarget;
                    nearestIslandDistance = checkDistance;
                }
            }
            
        }

        
        if(turrets.Length != 0)
        {
            for (int i = 0; i < turrets.Length; i++)
            {
                if (turrets[i] != null)
                {
                    Transform tempTurret = turrets[i].GetComponent<Transform>();
                    float checkDistance = Vector3.Distance(tempTurret.position, transform.position);

                    if (checkDistance < nearestIslandDistance)
                    {
                        turretTarget = tempTurret;
                        nearestTurretDistance = checkDistance;
                    }
                }
                    

                  
            }
        }
        
        
         playerDistance = Vector3.Distance(player.position, transform.position);

         if(playerDistance < range || nearestTurretDistance < range)
         {
              if(playerDistance < nearestTurretDistance)
              {
                  currentTarget = player;
              }
              else
              {
                  currentTarget = turretTarget;
              }
         }
         else
         {
              currentTarget = islandTarget;
         }
          
    }

    public void shootTarget()
    {
        if (Vector3.Distance(currentTarget.position, transform.position) > range)
            return;

        Vector3 originPosition = new Vector3(transform.position.x, 1.5f, transform.position.z);

        GameObject _projectile = Instantiate(enemyProjectile, originPosition, Quaternion.identity);
        Rigidbody projectileRB = _projectile.GetComponent<Rigidbody>();
        _projectile.GetComponent<EnemyProjectile>().setDamage(damage);

        projectileRB.AddForce(projectileSpeed * aimDirection * 10, ForceMode.Acceleration);
    }

    private void getAimDirection()
    {
        if (currentTarget == null)
            return;

        aimDirection = (currentTarget.position - transform.position).normalized;
        aimDirection.y = 0;
    }
}
