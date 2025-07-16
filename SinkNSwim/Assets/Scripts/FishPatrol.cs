using System.Runtime.CompilerServices;
using UnityEngine;

public class FishPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;

    private Transform currentPoint;

    public float speed;

    [SerializeField] SpriteRenderer fishSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        
        if(currentPoint == pointB.transform)
        {
            rb.linearVelocity = new Vector2(speed, 0);
            fishSprite.flipX = false;
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, 0);
            fishSprite.flipX = true;
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position,pointB.transform.position);
    }
}
