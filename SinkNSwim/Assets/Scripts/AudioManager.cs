using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioSource mainTheme;
    public AudioSource whiteNoiseTheme;
    public AudioSource menuTheme;

    public static AudioManager instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Main Manu" || (SceneManager.GetActiveScene().name == "Credits"))
        {
            menuTheme.Play();
            whiteNoiseTheme.Play();
        }
        else
        {
            mainTheme.Play();
            whiteNoiseTheme.Play();
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    
}
