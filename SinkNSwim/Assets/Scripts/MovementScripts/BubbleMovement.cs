using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using static System.TimeZoneInfo;
using UnityEngine.InputSystem;

public class BubbleMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    
    public Rigidbody2D rb;
    public float downStrength = 5f;
    public float horizontalStrength = 5f;
    public float speed = 5f;

    bool canMoveHorizontal;

    [SerializeField] float downwardCooldown = .5f;
    float cooldownTimer = 0f;
   
    //public ClamMovement clamMovementScript;
    public BubbleMovement bubbleMovementScript;

    //public GameObject pearl;
    public SpriteRenderer bubbleRenderer;

    public CinemachineCamera cam;
    //public Transform clamTarget;

    //public TMP_Text mergeText;
    //public TMP_Text swimUpText;
    //public TMP_Text swimDownText;
    //public TMP_Text arrowText;
    //public TMP_Text LeftRightText;

    //public AudioSource bubblePopAudio;
    //public AudioSource clamJumpAudio;

    public Vector3 startingPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        gameObject.tag = "Player";
        //GetComponent<Rigidbody2D>();
        //clamMovementScript.enabled = false;
        rb.gravityScale = 0f;
        canMoveHorizontal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && cooldownTimer <=0)
        {
           DownwardForce();
           canMoveHorizontal = true;
        }
           
        if (canMoveHorizontal)
        {
            HorizontalMovement();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Clam")
        {
            //Debug.Log("Collision Detected");
            //Destroy(gameObject);
            //clamMovementScript.enabled = true;
            //bubbleMovementScript.enabled = false;
            //cam.Follow = clamTarget;
            //mergeText.enabled = false;
            //swimUpText.enabled = true;
            //swimDownText.enabled = false;
            //LeftRightText.enabled = false;
            //pearl.SetActive(true);
        }

        if (other.gameObject.tag == "Pop")
        {
            //Object.FindFirstObjectByType<AudioManager>().Play("BubblePop");
            //bubblePopAudio.Play();
            bubbleRenderer.enabled = false;
            StartCoroutine(BubblePop());
        }
    }

    IEnumerator BubblePop()
    {
        yield return new WaitForSeconds(.5f);
        bubbleRenderer.enabled = true;
        transform.position = startingPosition;
    }

    void DownwardForce()
    {
        //clamJumpAudio.Play();
        rb.linearVelocity = Vector2.down * downStrength;
        rb.gravityScale = -1f;

        cooldownTimer = downwardCooldown;
    }

    void HorizontalMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    //private void OnMove(InputValue inputValue)
    //{
    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    rb.linearVelocity = inputValue.Get<Vector2>() * speed;
    //}
}
