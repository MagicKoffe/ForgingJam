using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuilding : MonoBehaviour
{
    Transform playerReticle;
    public bool buildMode;
    public GameObject buildUI;
    PlayerMoneyManager playerMoney;

    public BuildScriptableObject[] buildingSO;
    public int currentBuilding = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = GetComponent<PlayerMoneyManager>();
        playerReticle = GameObject.FindGameObjectWithTag("Reticle").GetComponent<Transform>();
        buildMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && buildMode)
        {
            placeBuilding();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            toggleBuild();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBuilding = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBuilding = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentBuilding = 2;
        }
    }

    private void placeBuilding()
    {
        BuildScriptableObject selecetdBuild = buildingSO[currentBuilding];

        if(playerMoney.getMoney() >= selecetdBuild.cost)
        {
            playerMoney.changeMoney(-selecetdBuild.cost);
            TurretTemplate newBuild = Instantiate(selecetdBuild.buildingModel, playerReticle.position, Quaternion.identity).GetComponent<TurretTemplate>();
            newBuild.passScriptableObject(selecetdBuild);
        }

    }

    private void toggleBuild()
    {
        if (buildMode)
        {
            buildMode = false;
            buildUI.SetActive(false);
        }
        else
        {
            buildMode = true;
            buildUI.SetActive(true);
        }
        
            
    }
}
