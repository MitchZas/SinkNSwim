using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClamAudio : MonoBehaviour
{
    [SerializeField] AudioSource clamMovementSFX;
    [SerializeField] AudioSource clamhitSFX;
    public void ClamMoveSFX()
    {
        clamMovementSFX.pitch = Random.Range(0.8f, 1.2f);
        clamMovementSFX.Play(); 
    }

    public void ClamHitSandSFX()
    {
        clamhitSFX.pitch = Random.Range(0.8f, 1.2f);
        clamhitSFX.Play();
    }
}
