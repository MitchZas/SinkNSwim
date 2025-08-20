using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CollectableLogic : MonoBehaviour
{
    [Header("Collectable Components")]
    [SerializeField] Canvas collectableCanvas;

    void Awake()
    {
        collectableCanvas.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            collectableCanvas.enabled = true;
        }
    }

}
