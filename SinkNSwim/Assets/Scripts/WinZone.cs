using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class WinZone : MonoBehaviour
{
    [SerializeField] LevelLoader levelLoaderScript;
    [SerializeField] GameObject pearl;
    [SerializeField] Timer timerScript;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Clam")
        {
            levelLoaderScript.LoadNextLevel();
            pearl.SetActive(false);
            // Add Score
        }
    }

    void CalculatScore()
    {
       //Switch statement
    }
}
