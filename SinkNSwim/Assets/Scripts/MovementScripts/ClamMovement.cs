using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ClamMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float upStrength = 20f;
    public float horizontalStrength = 3f;
    public SpriteRenderer clamSprite;

    public BubbleMovement bubbleMovementScript;
    public ClamMovement clamMovementScript;

    public AudioSource clamJumpAudio;
    public AudioSource clamHitAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        clamMovementScript.enabled = false;
        GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clamMovementScript.enabled == true)
        {
            rb.gravityScale = 3f;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Object.FindFirstObjectByType<AudioManager>().Play("ClamJump");
            clamJumpAudio.Play();
            rb.linearVelocity = Vector2.up * upStrength;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.linearVelocity = Vector2.left * horizontalStrength;
            clamSprite.flipX = true;
            transform.eulerAngles = new UnityEngine.Vector3(0, 0, -26);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.linearVelocity = Vector2.right * horizontalStrength;
            clamSprite.flipX = false;
            transform.eulerAngles = new UnityEngine.Vector3(0, 0, 26);
        }
    }
       private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Pop" && other.gameObject.layer == 6)
            {
                //Object.FindFirstObjectByType<AudioManager>().Play("ClamHit");
                clamHitAudio.Play();
                clamSprite.enabled = false;
                StartCoroutine(ClamPop());
            }
        }

    IEnumerator ClamPop()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
