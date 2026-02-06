using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    float damage = 5;

    public void setDamage(float _damage)
    {
        damage = _damage;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            //Progam dmg to enemy
            Destroy(gameObject);
        }
    }
}
