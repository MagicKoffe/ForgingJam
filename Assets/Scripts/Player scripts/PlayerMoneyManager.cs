using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMoneyManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyUI;
    int money;
        
    // Start is called before the first frame update
    void Start()
    {
        money = 50;
    }

    //Use positive ints to add, negative to take away
    public void changeMoney(int _money)
    {
        money += _money;
    }


    // Update is called once per frame
    void Update()
    {
        moneyUI.text = "GOLD: " + money;
    }
}
