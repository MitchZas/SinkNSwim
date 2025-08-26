using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using Unity.VisualScripting;

public class CMovement : MonoBehaviour
{
    [Header("Clam Components")]
    [SerializeField] SpriteRenderer clamSprite;
    private InputSystem_Actions clamControls;
    private Rigidbody2D rb;

    [Header("Horiztonal Movement Settings")]
    [SerializeField] private float horizontalStrength = 5f;
    private float horizontal;
    private bool canMoveHorizontal;

    [Header("Upward Movement Settings")]
    [SerializeField] private float upStrength = 20f;
    //[SerializeField] PlayerInput clamPlayerInput;
    private float distance;

    [Header("Jump Cooldown")]
    [SerializeField] private float jumpCooldown = 1f;
    private bool canJump = true;
    private float nextJumpTime = 0f;

    #region UNITY ESSENTIALS    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        clamControls = new InputSystem_Actions();
        canMoveHorizontal = false;
    }

    void FixedUpdate()
    {
        rb.gravityScale = 3f;
        HoriontalMovement();
    }
    #endregion

    #region PLAYER CONTROLS
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Time.time < nextJumpTime) return;

            rb.linearVelocity = new Vector2(rb.linearVelocity.x, upStrength);

            nextJumpTime = Time.time + jumpCooldown;
            return;
        }
        if (context.canceled)
        {
            if (rb.linearVelocity.y > 0f)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
    }
    void HoriontalMovement()
    {
        rb.linearVelocity = new Vector2(horizontal * horizontalStrength, rb.linearVelocity.y);

        if (horizontal > 0.01f)
        {
            clamSprite.flipX = false;
        }
        else if (horizontal < -0.01f)
        {
            clamSprite.flipX = true;
        }
    }
    void ApplyUpwardForce(float distance)
    {
        canMoveHorizontal = true;
        rb.linearVelocity = Vector2.up * (upStrength * distance);
        Debug.Log(distance);
    }
    private IEnumerator JumpCooldownTimer()
    {
        canJump = false; // stop jumps
        yield return new WaitForSeconds(jumpCooldown); // wait X seconds
        canJump = true;  // allow jumping again
    }
    #endregion
}
