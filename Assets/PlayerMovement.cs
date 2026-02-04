using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float acceleration;
    [SerializeField] float turningSpeed;
    [SerializeField] float sailSpeed;
    [SerializeField] float rowSpeed;

    bool sailsUp;
    Vector3 directionInput;

    Rigidbody _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        applyMovement();
    }

    private void applyMovement()
    {
        if (sailsUp)
            _rigidbody.AddForce(sailSpeed * transform.forward);


    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    private void getInput()
    {
        
    }
}
