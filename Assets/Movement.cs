using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public MovementController controller;

    private float _runSpeed = 40f;
    private float _horizontalMove = 0f;
    private float _verticalJumpAdjustment = 100f;
    private bool _discharge = false;
    private float _charger = 0f;
    private float _tempMove = 0f;

    // Update is called once per frame
    void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;

        if (Input.GetKey(KeyCode.Space))
        {
            _tempMove = _horizontalMove;
            _charger += Time.deltaTime;
            _horizontalMove = 0f;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _discharge = true;
        }
    }

    private void FixedUpdate()
    {
        if (_discharge)
        {
            controller.Jump(_tempMove * Time.fixedDeltaTime * _charger * _verticalJumpAdjustment, _charger);
            _discharge = false;
            _charger = 0f;
        }
        controller.Move(_horizontalMove * Time.fixedDeltaTime, false, _discharge,_charger);
    }
}
