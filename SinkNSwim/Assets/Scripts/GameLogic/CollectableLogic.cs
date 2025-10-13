using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class CollectableLogic : MonoBehaviour
{
    [Header("Collectable Components")]
    [SerializeField] GameObject coinTextPanel;
    [SerializeField] GameObject coinImagePanel;
    [SerializeField] GameObject Coin;

    public TMP_Text coinText;
    public int coinsCollected = 0;

    void Awake()
    {
        coinTextPanel.SetActive(false);
        coinImagePanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Collect"))
        {
            coinTextPanel.SetActive(true);
            coinImagePanel.SetActive(true);
            coinsCollected++;
            coinText.text = coinsCollected.ToString();
            Debug.Log(coinsCollected);
            Destroy(collider.gameObject);
        }
    }
}
