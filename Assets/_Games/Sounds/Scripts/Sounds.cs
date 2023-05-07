using System;
using UnityEngine;


namespace Sounds
{
    public class Sounds : MonoBehaviour
    {
        [SerializeField] private AudioYB _yandexAudio;
        [SerializeField] private AudioStreamCash _cash;
        private static AudioYB yandexAudio;
        private static AudioStreamCash cash;

        public static event Action onEndSound;


        private static float _soundTimeLeft = 0f;

        private void Awake()
        {
            yandexAudio = _yandexAudio;
            cash = _cash;
        }

        public static void Stop()
        {
            yandexAudio.Stop();
            onEndSound?.Invoke();
        }

        public static void Play(string audioName)
        {
            yandexAudio.Stop();
            onEndSound?.Invoke();

            yandexAudio.Play(audioName);

            foreach (var info in cash.infoList)
                if (info.Name == audioName)
                {
                    _soundTimeLeft = info.Cash.length;
                    break;
                }


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
}



