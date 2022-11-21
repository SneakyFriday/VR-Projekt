using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnObject : MonoBehaviour
{
    /**
     * Attach on Objects to Play Sound on them
     */
    [SerializeField] private AudioClip _clip;
    private AudioSource _objectAudioSource;

    private void Start()
    {
        _objectAudioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        _objectAudioSource.PlayOneShot(_clip);
    }
}
