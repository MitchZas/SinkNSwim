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
    private Rigidbody2D rb;
    private InputSystem_Actions playerControls;

    [Header("Movement Settings")]
    [SerializeField] private float upStrength = 20f;
    [SerializeField] BMovement bubbleMovementScript;
    [SerializeField] CMovement clamMovementScript;
    [SerializeField] private float horizontalStrength = 5f;
    private float horizontal;
    private bool canMoveHorizontal;

    void Start()
    {
        clamMovementScript.enabled = false;
        GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            ApplyUpwardForce(1);
        }
        else if (context.canceled)
        {
            ApplyUpwardForce(.5f);
        }
    }


    void HoriontalMovement()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x , rb.linearVelocity.y * upStrength);
    }

    void ApplyUpwardForce(float distance)
    {
        canMoveHorizontal = true;
        rb.linearVelocity = Vector2.up * (upStrength * distance);
    }
    #endregion
}
