using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI velocityText;
    [SerializeField] float turningSpeed;
    [SerializeField] float sailSpeed;
    [SerializeField] float rowSpeed;

    [SerializeField] GameObject sailModel;
    public bool sailsUp;
    float rotationInput;
    float movementInput;

    Rigidbody _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        applyMovementAndRotation();
    }

    private void applyMovementAndRotation()
    {
        if (sailsUp)
            _rigidbody.AddForce(sailSpeed * transform.forward);
        else
            _rigidbody.AddForce(rowSpeed * movementInput * transform.forward);

        float rotation = rotationInput * turningSpeed;
        Quaternion turnRotation = Quaternion.Euler(0, rotation, 0);
        _rigidbody.MoveRotation(_rigidbody.rotation * turnRotation);
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
        //updateUI();
    }

    private void updateUI()
    {
        var playerVelocityToText = "Velocity= " + _rigidbody.velocity.magnitude;
        //velocityText.text = playerVelocityToText;
    }

    private void getInput()
    {
        rotationInput = Input.GetAxis("Horizontal");
        movementInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggleSails();
        }

    }

    private void toggleSails()
    {
        if (sailsUp)
        {
            sailsUp = false;
            sailModel.SetActive(false);
        }
        else
        {
            sailsUp = true;
            sailModel.SetActive(true);
        }
    }
}
