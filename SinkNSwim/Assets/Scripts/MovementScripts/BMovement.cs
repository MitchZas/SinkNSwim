using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class BMovement : MonoBehaviour
{
    [Header("Bubble Components")]
    private InputSystem_Actions bubbleControls;
    private Rigidbody2D rb;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float horizontalStrength = 5f;
    private float horizontal;
    private bool canMoveHorizontal;

    [Header("Downward Force Parameters")]
    [SerializeField] private float downStrength = 5f;
    private float distance;

    [Header("Other Scripts")]
    [SerializeField] GameManager gameManager;

    [Header("Jump Cooldown")]
    [SerializeField] private float jumpCooldown = 1f;
    private bool canJump = true;

    #region UNITY ESSENTIALS
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bubbleControls = new InputSystem_Actions();
        rb.gravityScale = 0f;
        canMoveHorizontal = false;
    }

    void FixedUpdate()
    {
        if (canMoveHorizontal)
        {
            HoriontalMovement();
        }
    }
    #endregion

    #region PLAYER CONTROLS
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!canJump)
        {
            return;
        }
        
        if (context.performed)
        {
            ApplyDownwardForce(1);
            StartCoroutine(JumpCooldownTimer());
        }
        else if (context.canceled)
        {
            ApplyDownwardForce(.5f);
            StartCoroutine(JumpCooldownTimer());
        }
    }
    
    void HoriontalMovement()
    {
        rb.linearVelocity = new Vector2(horizontal * horizontalStrength, rb.linearVelocity.y);
    }
   
    void ApplyDownwardForce(float distance)
    {
        canMoveHorizontal = true;
        rb.linearVelocity = Vector2.down * (downStrength * distance);
        rb.gravityScale = -1f;
    }

    private IEnumerator JumpCooldownTimer()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Clam")
        {
            gameManager.SwitchPlayer();
        }
    }
}
