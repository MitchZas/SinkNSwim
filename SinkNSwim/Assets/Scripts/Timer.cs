using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    [Header("Timer Components")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] Canvas timerTextCanvas;
    [SerializeField] float remainingTime = 30;
    [SerializeField] PearlState pearlScrpt;
  
    private void Awake()
    {
        timerTextCanvas.enabled = false;
    }
    void Update()
    {
        if (pearlScrpt.isDestroyed == true)
        {
            StartTimer();
            TimerColorChange();
            HandGrab();
        }
    }
    public void StartTimer()
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


        timerText.text = string.Format("{00:00}:{1:00}", minutes, seconds);
        //

        Debug.Log(remainingTime);
    }

    public void TimerColorChange()
    {
        int displaySeconds = Mathf.FloorToInt(remainingTime % 60);

        if (displaySeconds > 10 && displaySeconds < 16)
        {
            timerText.color = Color.yellow;
        }
        else if (displaySeconds >= 0 && displaySeconds <= 10) 
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.white;
        }
    }

    public void HandGrab()
    {
        if (remainingTime == 0)
        {
            Debug.Log("Hands come into tank");
        }
    }
}
