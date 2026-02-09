using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAiming : MonoBehaviour
{
    //This script handles the position of the reticle

    Transform worldReticle;
    Vector3 worldMousePosition;
    PlayerBuilding playerBuidling;

    SpriteRenderer reticleImage;
    public Sprite normalReticel;
    public Sprite buildReticle;

    // Start is called before the first frame update
    void Start()
    {
        playerBuidling = GetComponent<PlayerBuilding>();
        worldReticle = GameObject.FindGameObjectWithTag("Reticle").GetComponent<Transform>();
        reticleImage = worldReticle.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        positionReticle();

        checkBuildingMode();
    }

    private void checkBuildingMode()
    {
        if (playerBuidling.buildMode)
        {
            reticleImage.sprite = buildReticle;
        }
        else
        {
            reticleImage.sprite = normalReticel;
        }
    }

    private void positionReticle()
    {
        Vector3 screenPosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);

        if(Physics.Raycast(ray, out RaycastHit hitData))
        {
            worldMousePosition = hitData.point;   
        }

        worldReticle.position = new Vector3(worldMousePosition.x, 1.5f, worldMousePosition.z);
    }

    
}
