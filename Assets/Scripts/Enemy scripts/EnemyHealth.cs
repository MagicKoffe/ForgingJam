using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 10;
    float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            enemyDie();
        }
    }

    private void enemyDie()
    {
        //Play sinking animation
        //Drop gold for player to collect

        Destroy(gameObject);
    }
}
