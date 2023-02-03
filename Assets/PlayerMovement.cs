using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float _playerSpeed = 8f;
    [SerializeField] private float _dashSpeed = 16f;
    
    
    private bool isDashAvailable = true;
    private float dashCooldown = 100;
    
    void Update()
    {
        InputSystem.Update();
        //TODO make camera move
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {   
        Vector2 newVelocityVector = context.ReadValue<Vector2>();
        playerRB.velocity = new Vector2(newVelocityVector.x * _playerSpeed, newVelocityVector.y * _playerSpeed);
    }

    public void ActivateDash(InputAction.CallbackContext context)
    {
        //TODO Fix Action while other movement is currently pressed 
        if (context.performed && isDashAvailable)
        {
            _playerSpeed = _dashSpeed;
            isDashAvailable = false;
        }
    }
}
