using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectableLogic : MonoBehaviour
{
    [Header("Collectable Components")]
    [SerializeField] Canvas collectableCanvas;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Collectiable;

    public bool isCollected;
    public int coinsCollected = 0;

    //private int CollectibleCount = 0;

    void Awake()
    {
        collectableCanvas.enabled = false;
        isCollected = false;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Player)
        {
            Collectiable.SetActive(false);
            isCollected = true;
            collectableCanvas.enabled = true;
            coinsCollected++;
            Debug.Log(coinsCollected);
        }
    }
}
