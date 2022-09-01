using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public MovementController controller;
    public Rigidbody2D _rb;
    public Animator animator;

    private float _runSpeed = 40f;
    private float _horizontalMove = 0f;
    private float _verticalJumpAdjustment = 100f;
    private bool _discharge = false;
    private float _charger = 0f;
    private float _tempMove = 0f;
    private static readonly int SideSpeed = Animator.StringToHash("Side_Speed");
    private static readonly int JumpUp = Animator.StringToHash("Jump_Up");
    private static readonly int JumpDown = Animator.StringToHash("Jump_Down");


    // Update is called once per frame
    void Update()
    {
        _horizontalMove = Input.GetAxisRaw("Horizontal") * _runSpeed;
        
        animator.SetFloat(SideSpeed,Mathf.Abs(_horizontalMove));
        
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool(JumpUp,true);
            _tempMove = _horizontalMove;
            _charger += Time.deltaTime;
            _horizontalMove = 0f;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool(JumpUp,true);
            _discharge = true;
        }

        if (_rb.velocity.y < 0f && Math.Abs(_horizontalMove) > 0f)
        {
            animator.SetBool(JumpUp,false);
            animator.SetBool(JumpDown,true);
        }
        else
        {
            animator.SetBool(JumpDown,false);
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
        controller.Move(_horizontalMove * Time.fixedDeltaTime, false);

    }
}
