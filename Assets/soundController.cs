using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    public static soundController Instance;

    private AudioSource audioSource;
    public float jumpSoundVolume = 0.0000000001f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void startSound(AudioClip sound)
    {
        audioSource.volume = jumpSoundVolume;
        audioSource.PlayOneShot(sound);

    }
}
