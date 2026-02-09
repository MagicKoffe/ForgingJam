using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretProjectile : MonoBehaviour
{
    float damage;
    float lifeTime;

    //Varibale used for arc calculations
    bool isTracking;
    Vector3 origin;
    Transform targetPoint;
    float projectileSpeed;

    Vector3 currentPosition;
    float distanceTravelled;
    float arcFactor = 0.75f;

    public void setStats(float _damage, float _lifeTime)
    {
        damage = _damage;
        lifeTime = _lifeTime;

        StartCoroutine(startLifetime());
    }

    private IEnumerator startLifetime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            collision.transform.GetComponent<EnemyHealth>().takeDamage(damage);
        }
        Destroy(gameObject);
    }

    //--------------------------------------------------ALL BELOW IS FOR ARCING PROJECTILES--------------------------------------------------
    public void arcTowardsTarget(Vector3 _origin, Transform _targetPoint, float _projectileSpeed)
    {
        isTracking = true;
        origin = _origin;
        targetPoint = _targetPoint;
        projectileSpeed = _projectileSpeed;
        currentPosition = transform.position;

    }

    private void Update()
    {
        if (!isTracking)
            return;

        // Move ourselves towards the target at every frame.
        Vector3 direction = targetPoint.position - currentPosition;
        currentPosition += direction.normalized * projectileSpeed * Time.deltaTime;
        distanceTravelled += projectileSpeed * Time.deltaTime; // Record the distance we are travelling.

        // Set our position to <currentPosition>, and add a height offset to it.
        float totalDistance = Vector3.Distance(origin, targetPoint.position);
        float heightOffset = arcFactor * totalDistance * Mathf.Sin(distanceTravelled * Mathf.PI / totalDistance);
        transform.position = currentPosition + new Vector3(0, heightOffset, 0);

        if (transform.position.y <= 1f)
        {
            Destroy(gameObject);
        }

    }
}
