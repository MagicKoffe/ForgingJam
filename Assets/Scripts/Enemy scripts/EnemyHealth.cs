using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;

    public GameObject lootSpawn;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float damage)
    {
        Debug.Log("Take damage: " + damage);
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            enemyDie();
        }
    }

    private void enemyDie()
    {
        Instantiate(lootSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
