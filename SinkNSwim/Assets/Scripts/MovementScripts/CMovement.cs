using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class CMovement : MonoBehaviour
{
    [Header("Clam Components")]
    [SerializeField] SpriteRenderer clamSprite;
    [SerializeField] CMovement clamMovementScript;
    private InputSystem_Actions clamControls;
    private Rigidbody2D rb;

    [Header("Horiztonal Movement Settings")]
    [SerializeField] BMovement bubbleMovementScript;
    [SerializeField] private float horizontalStrength = 5f;
    private float horizontal;
    private bool canMoveHorizontal;

    [Header("Upward Movement Settings")]
    [SerializeField] private float upStrength = 20f;
    [SerializeField] PlayerInput clamPlayerInput;
    private float distance;

    [Header("Jump Cooldown")]
    [SerializeField] private float jumpCooldown = 1f;
    private bool canJump = true;

    #region UNITY ESSENTIALS    
    void Start()
    {
        clamMovementScript.enabled = false;
        clamPlayerInput.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        clamControls = new InputSystem_Actions();
        canMoveHorizontal = false;
    }

    void FixedUpdate()
    {
        if (clamMovementScript.enabled == true)
        {
            clamPlayerInput.enabled = true;
            rb.gravityScale = 3f;
        }

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
        if (!canJump)
        {
            return;
        }

        if (context.performed)
        {
            ApplyUpwardForce(1);
            StartCoroutine(JumpCooldownTimer());
        }
        else if (context.canceled)
        {
            ApplyUpwardForce(.25f);
            StartCoroutine(JumpCooldownTimer());
        }
    }
    void HoriontalMovement()
    {
        rb.linearVelocity = new Vector2(horizontal * horizontalStrength, rb.linearVelocity.y);
    }

    void ApplyUpwardForce(float distance)
    {
        canMoveHorizontal = true;
        rb.linearVelocity = Vector2.up * (upStrength * distance);
        Debug.Log(distance);
    }
    #endregion
    private IEnumerator JumpCooldownTimer()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpCooldown);
        canJump = true;
    }
}
