using Unity.VisualScripting;
using UnityEngine;

public class HandSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject Hand;
    [SerializeField] float spawnRate;
    private float timer = 0;
    [SerializeField] public Transform clamTransform;
    [SerializeField] float xOffset;
    [SerializeField] HandMoveScript HandMoveScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnHands();
            timer = 0;
        }
    }

    void SpawnHands()
    {
        float leftmostPoint = clamTransform.position.x - xOffset;
        float rightmostPoint = clamTransform.position.x + xOffset;
        
        Instantiate(Hand, new Vector3(Random.Range(leftmostPoint, rightmostPoint), transform.position.y, 0), transform.rotation);
    }
}
