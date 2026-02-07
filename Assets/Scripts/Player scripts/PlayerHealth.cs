using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    float currentHealth;

    [SerializeField] Image healthBarUI;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void changeHealth(float hp)
    {
        currentHealth += hp;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        if (currentHealth <= 0)
            playerDie();
    }

    private void playerDie()
    {
        //Kill player
    }

    private void Update()
    {
        healthBarUI.fillAmount = currentHealth / maxHealth;
    }

}
