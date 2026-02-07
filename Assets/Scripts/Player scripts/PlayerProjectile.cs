using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    float damage;

    //Varibale used for arc calculations
    bool isArcing;
    Vector3 origin;
    Vector3 targetPoint;
    float projectileSpeed;

    Vector3 currentPosition;
    float distanceTravelled;
    float arcFactor = 0.5f;
    //

    public void setDamage(float _damage)
    {
        damage = _damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<EnemyHealth>().takeDamage(damage);
        }
        Destroy(gameObject);
    }

    //--------------------------------------------------ALL BELOW IS FOR ARCING PROJECTILES--------------------------------------------------
    public void arcTowardsTarget(Vector3 _origin, Vector3 _targetPoint, float _projectileSpeed)
    {
        isArcing = true;
        origin = _origin;
        targetPoint = _targetPoint;
        projectileSpeed = _projectileSpeed;
        currentPosition = transform.position;

    }

    private void Update()
    {
        if (!isArcing)
            return;

        // Move ourselves towards the target at every frame.
        Vector3 direction = targetPoint - currentPosition;
        currentPosition += direction.normalized * projectileSpeed * Time.deltaTime;
        distanceTravelled += projectileSpeed * Time.deltaTime; // Record the distance we are travelling.

        // Set our position to <currentPosition>, and add a height offset to it.
        float totalDistance = Vector3.Distance(origin, targetPoint);
        float heightOffset = arcFactor * totalDistance * Mathf.Sin(distanceTravelled * Mathf.PI / totalDistance);
        transform.position = currentPosition + new Vector3(0, heightOffset, 0);

        if(transform.position.y <= 1f)
        {
            Destroy(gameObject);
        }

    }


}
