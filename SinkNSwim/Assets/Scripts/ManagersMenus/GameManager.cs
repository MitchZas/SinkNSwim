using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.Cinemachine;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource buttonClickAudio;
    
    [Header("Gameplay Info")]
    [SerializeField] CMovement clamMovementScript;
    [SerializeField] GameObject clam;
    [SerializeField] CinemachineCamera cam;
    [SerializeField] Transform clamTarget;
    [SerializeField] CollectableLogic coinsCollectedScript;
    [SerializeField] GameObject Collectiable;
    [SerializeField] TMP_Text coinText;

    #region UNITY ESSENTIALS
    private void Update()
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
}
