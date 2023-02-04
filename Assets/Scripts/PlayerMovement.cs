using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private float _normalSpeed = 8f;
    [SerializeField] private float _playerSpeed;

    [SerializeField] private Vector2 moveVector;

    [SerializeField] private Animator _playerAnim;

    [Header("Dash")] 
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashingSpeed = 32f;
    [SerializeField] private float dashingTime = 0.3f;
    [SerializeField] private float dashingCooldown = 1f;
  
    
    
    private void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerSpeed = _normalSpeed;

    }


    void Update()
    {
        playerRB.velocity = new Vector2(moveVector.x * _playerSpeed, moveVector.y * _playerSpeed);
        SetDirectionValues();
    }

    public void MovePlayer(InputAction.CallbackContext context)
    {   
        moveVector = context.ReadValue<Vector2>();
    }

    public void ActivateDash(InputAction.CallbackContext context)
    {
        //TODO Fix Action while other movement is currently pressed 
        if (context.performed && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    public void SetDirectionValues()
    {
        _playerAnim.SetFloat("moveVector.x", moveVector.x);
        _playerAnim.SetFloat("moveVector.y", moveVector.y);
    }


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        _playerSpeed = dashingSpeed;
        yield return new WaitForSeconds(dashingTime);
        isDashing = false;
        _playerSpeed = _normalSpeed;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    
}
