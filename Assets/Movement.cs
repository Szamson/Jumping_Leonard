using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public MovementController controller;

    private float _runSpeed = 40f;
    private float _horizontalMove = 0f;
    private float _verticalMove = 0f;
    private bool _jump = false;
    
    // Update is called once per frame
    void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;
        _verticalMove = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            _jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(_horizontalMove * Time.fixedDeltaTime, false, _jump);
        _jump = false;
    }
}
