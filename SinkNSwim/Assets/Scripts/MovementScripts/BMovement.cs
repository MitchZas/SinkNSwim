using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class BMovement : MonoBehaviour
{
    [Header("Bubble Components")]
    private Rigidbody2D rb;
    private InputSystem_Actions playerControls;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float horizontalStrength = 5f;
 

    [Header("Downward Force Parameters")]
    [SerializeField] private float downStrength = 5f;
    
    
    private float distance;
    private float horizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new InputSystem_Actions();
        rb.gravityScale = 0f;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * moveSpeed,rb.linearVelocity.y);
    }

    #region PLAYER CONTROLS
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ApplyDownwardForce(1);
        }
        else if (context.canceled)
        {
            ApplyDownwardForce(.5f);
        }
    }
    #endregion


    void ApplyDownwardForce(float distance)
    {
        rb.linearVelocity = Vector2.down * (downStrength * distance);
        rb.gravityScale = -1f;
    }
}
