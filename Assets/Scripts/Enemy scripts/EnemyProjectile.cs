using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    float damage = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerHealth>().changeHealth(-damage);
        }

        Destroy(gameObject);
    }

    public void setDamage(float _damage)
    {
        damage = _damage;
    }
}
