using UnityEngine;

public class ClamCollision : MonoBehaviour
{
    [SerializeField] GameObject Clam;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Clam) 
        { 
            Clam.SetActive(false);
        }
    }

}
