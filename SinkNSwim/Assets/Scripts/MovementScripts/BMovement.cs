using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class BMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float horizontalStrength = 5f;

    [Header("Downward Force Parameters")]
    [SerializeField] private float downStrength = 5f;
    [SerializeField] private float downwardCooldown = .5f;
    
    private float cooldownTimer = 0f;
    private bool isMovingDown;

    private Rigidbody2D rb;
    private InputSystem_Actions playerControls;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new InputSystem_Actions();
        rb.gravityScale = 0f;
        isMovingDown = false;
    }

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (isMovingDown == true && cooldownTimer <=0)
        {
            cooldownTimer = downwardCooldown;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ApplyFullDownwardForce();
        }
        else if (context.canceled)
        {
            ApplyHalfDownwardForce();
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    void ApplyFullDownwardForce()
    {
        isMovingDown = true;
        rb.linearVelocity = Vector2.down * downStrength;
        rb.gravityScale = -1f;
    }

    void ApplyHalfDownwardForce()
    {
        isMovingDown = true;
        rb.linearVelocity = Vector2.down * (downStrength * .5f);
        rb.gravityScale = -1f;
    }
}
