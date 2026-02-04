using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    Transform directionalLight;
    [SerializeField] float rotationSpeed;
    void Start()
    {
        directionalLight = GameObject.FindGameObjectWithTag("Light").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        directionalLight.Rotate(new Vector3(1, 0, 0) * rotationSpeed * Time.deltaTime);
    }
}
