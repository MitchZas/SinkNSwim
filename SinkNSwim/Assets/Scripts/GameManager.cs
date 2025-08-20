using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public AudioSource buttonClickAudio;
    
    [Header("Gameplay Info")]
    [SerializeField] BMovement bubbleMovementScript;
    [SerializeField] CMovement clamMovementScript;
    [SerializeField] GameObject bubble;
    [SerializeField] GameObject clam;
    [SerializeField] CinemachineCamera cam;
    [SerializeField] Transform clamTarget;

    

    #region UNITY ESSENTIALS
    private void Awake()
    {
        
    }
    #endregion

    #region GameState
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    #endregion

    public void SwitchPlayer()
    {
        Destroy(bubble);
        clamMovementScript.enabled = true;
        clam.GetComponent<PlayerInput>().enabled = true;
        bubbleMovementScript.enabled = false;
        cam.Follow = clamTarget;
        // Enable Pearl 
    }


}
