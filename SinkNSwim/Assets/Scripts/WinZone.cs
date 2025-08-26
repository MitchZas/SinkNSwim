using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class WinZone : MonoBehaviour
{
    [SerializeField] LevelLoader levelLoaderScript;
    [SerializeField] GameObject Pearl;
    [SerializeField] Timer timerScript;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pearl"))
        {
            Debug.Log(other.gameObject.name);
            levelLoaderScript.LoadNextLevel();
            //Pearl.SetActive(false);
        }
    }
}
