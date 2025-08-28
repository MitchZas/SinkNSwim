using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

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
    private float distance;

    [Header("Jump Cooldown")]
    [SerializeField] private float jumpCooldown = 1f;
    private bool canJump = true;
    private float nextJumpTime = 0f;

    [Header("Ground Check")]
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    [Header("Audio")]
    [SerializeField] ClamAudio clamAudioscript;
    private bool wasGrounded = true;

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
        
        if (canMoveHorizontal)
        {
            HoriontalMovement();
        }

        if(isGrounded())
        {
            canMoveHorizontal = false;
        }
    }
    #endregion

    #region GROUND CHECK
    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            Debug.Log("Ground hit");
            return true;
        }
        else
        {
            Debug.Log("Ground missed");
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position -transform.up * castDistance, boxSize);
    }
    #endregion

    #region PLAYER CONTROLS
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        canMoveHorizontal = true;


        if (context.performed)
        {
            clamAudioscript.ClamMoveSFX();

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (!wasGrounded) // only play if we weren't already grounded
            {
                clamAudioscript.ClamHitSandSFX();
            }
            wasGrounded = true; // now we're grounded
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            wasGrounded = false; // left the ground
        }
    }
}
