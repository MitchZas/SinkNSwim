using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    public float remainingTime = 30f;
    void Update()
    {
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

        CalculatScore();
    }

    void CalculatScore()
    {
       if (remainingTime > 20 && remainingTime <=30)
        {
            Debug.Log("Great");
            timerText.color = Color.green;
            // Give a score of 20 pts
        }
       else if (remainingTime >=11 && remainingTime <= 20)
        {
            Debug.Log("Good");
            timerText.color = Color.yellow;
            // Give a score of 10 pts 
        }
       else
        {
            Debug.Log("Bad");
            timerText.color = Color.red;
            // Give a score of 5 pts 
        }
    }
}
