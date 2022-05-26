using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip coinGrab;
    public AudioClip click;
    public AudioClip jump;

    public AudioSource effectsSource;
    private bool muted;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMuted()
    {
        muted = !muted;
        audioSource.mute = muted;
    }

    public bool GetMuted()
    {
        return muted;
    }

    public void PlayOnceClick()
    {
        if (muted) return;
        effectsSource.PlayOneShot(click, 1f);
    }
    public void PlayOnceJump()
    {
        if (muted) return;
        effectsSource.PlayOneShot(jump, 1f);
    }
    public void PlayCoinGrab()
    {
        if (muted) return;
        effectsSource.PlayOneShot(coinGrab, 1f);
    }
}
