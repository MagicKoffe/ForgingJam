using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    //This script handles the position of the reticle

    Transform worldReticle;
    Vector3 worldMousePosition;

    // Start is called before the first frame update
    void Start()
    {
        worldReticle = GameObject.FindGameObjectWithTag("Reticle").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        positionReticle();      
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
