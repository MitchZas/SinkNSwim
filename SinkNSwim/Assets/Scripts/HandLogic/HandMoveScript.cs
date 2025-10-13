using UnityEngine;

public class HandMoveScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    HandSpawnerScript HandSpawnerScript;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;
        HandRetreat();
    }

    void HandRetreat()
    {
        GameObject handTop = GameObject.Find("HandTop");

        if (HandSpawnerScript.clamTransform.position.y - handTop.transform.position.y > -10)
        {
            moveSpeed = 0;
        }

        if (moveSpeed == 0)
        {
            transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;
        }
    }
}
