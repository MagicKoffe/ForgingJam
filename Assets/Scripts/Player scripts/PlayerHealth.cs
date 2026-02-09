using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float fixRange = 5f;
    float currentHealth;
    GameManager gameManager;
    Transform port;
    PlayerMoneyManager pmm;
    public GameObject fixUI;

    [SerializeField] Image healthBarUI;

    private void Start()
    {
        currentHealth = maxHealth;
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        port = GameObject.FindGameObjectWithTag("Port").GetComponent<Transform>();
        pmm = GetComponent<PlayerMoneyManager>();
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
        gameManager.gameOver();
    }

    private void Update()
    {
        healthBarUI.fillAmount = currentHealth / maxHealth;

        if(Vector3.Distance(transform.position, port.position) < fixRange)
        {
            fixUI.SetActive(true);

            if (Input.GetKeyDown(KeyCode.R) && pmm.getMoney() >= 20){
                changeHealth(30);
                pmm.changeMoney(-20);
                
            }
        }
        else
        {
            fixUI.SetActive(false);
        }
    }

}
