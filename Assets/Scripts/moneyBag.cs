using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyBag : MonoBehaviour
{
    public int moneyValueMin = 10;
    public int moneyValueMax = 20;

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
        int value = UnityEngine.Random.Range(moneyValueMin,moneyValueMax + 1);

        pmm.changeMoney(value);
        Destroy(gameObject);
    }
}
