using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyBag : MonoBehaviour
{
    public int moneyValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            collectMoneyBag(other.GetComponent<PlayerMoneyManager>());
        }
    }

    //When player runs into this object, add its value to the money counter and destroy it
    private void collectMoneyBag(PlayerMoneyManager pmm)
    {
        pmm.changeMoney(moneyValue);
        Destroy(gameObject);
    }
}
