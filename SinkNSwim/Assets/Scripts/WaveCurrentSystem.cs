using UnityEngine;

public class WaveCurrentSystem : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject current;

    [SerializeField] float currentForce;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == current)
        {
            Debug.Log("Current system activated");
            rb.AddForceX(currentForce, ForceMode2D.Impulse);
        }
    }
}
