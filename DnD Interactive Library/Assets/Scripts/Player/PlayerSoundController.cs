using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void PlayMoveSound()
    {
        if (!_audio.isPlaying)
        {
            _audio.volume = Random.Range(0.9f, 1f);
            _audio.pitch = Random.Range(0.8f, 1.1f);
            _audio.Play();
        }
    }
}
