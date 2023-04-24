using System;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static event Action onEndSound;


    private static AudioSource _playingAudio;

    private static float _soundTimeLeft = 0f;


    public static void Stop()
    {
        _playingAudio.Stop();
        onEndSound?.Invoke();
    }

    public static void Play(AudioSource audio)
    {
        _playingAudio?.Stop();
        onEndSound?.Invoke();

        _playingAudio = audio;
        _playingAudio.Play();

        _soundTimeLeft = _playingAudio.clip.length;
    }


    private void Update()
    {
        if (_soundTimeLeft > 0)
        {
            if (_soundTimeLeft - Time.deltaTime < 0)
            {
                _soundTimeLeft = 0;
                onEndSound?.Invoke();
            }
            else _soundTimeLeft -= Time.deltaTime;
        }
        
    }





}

