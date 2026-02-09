using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class baseScript : MonoBehaviour
{
    GameManager gm;
    public Image healthBar;
    public float maxHealth = 50;
    float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
        currentHP = maxHealth;
    }

    public void TakeDmg(float dmg)
    {
        currentHP -= dmg;

        Debug.Log("Took dmg");
        Debug.Log(currentHP);

        if (currentHP <= 0)
        {
            healthBar.fillAmount = 0;
            gm.islandDestroyed();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHP / maxHealth;
    }
}
