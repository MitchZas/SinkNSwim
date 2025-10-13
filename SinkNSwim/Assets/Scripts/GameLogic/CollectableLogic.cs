using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CollectableLogic : MonoBehaviour
{
    [Header("Collectable Components")]
    [SerializeField] Canvas collectableCanvas;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Collectiable;

    //private int CollectibleCount = 0;

    void Awake()
    {
        collectableCanvas.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Player)
        {
            Collectiable.SetActive(false);
            //Destroy(this.gameObject);
            collectableCanvas.enabled = true;
            Debug.Log("Other Collider:" + collider.name);
            //CollectibleCount++; 
        }
    }
}
