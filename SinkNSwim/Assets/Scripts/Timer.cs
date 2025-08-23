using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    [Header("Timer Components")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Canvas timerTextCanvas;
    [SerializeField] float remainingTime = 30f;
  
    private void Awake()
    {
        timerTextCanvas.enabled = false;
    }
    void Update()
    {
        //if (bubbleMovementScript.isAlive == false)
        //{
        //    StartTimer();
        //}
    }
    void StartTimer()
    {
        timerTextCanvas.enabled = true;
        
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
