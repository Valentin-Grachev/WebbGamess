using System;
using System.Collections.Generic;
using UnityEngine;


namespace AdService
{
    public class RewardedAds : MonoBehaviour
    {
        public enum ShowCallback { Success, NotAvailable }

        private static RewardedAds instance;
        public static Action onAvailable;

        private static bool adShowing = false;

        [SerializeField] private List<AdRewardedService> adRewardedServices;

        [Space(10)]
        [SerializeField] private bool showLogs;
        [SerializeField] private bool _useTestAds; public static bool useTestAds { get => instance._useTestAds; }
        [SerializeField] private bool skipAds;


        public static void Log(string message)
        {
            if (instance.showLogs) Debug.Log(message);
        }



        public static bool available
        {
            get
            {
                foreach (var service in instance.adRewardedServices)
                    if (service.available) return true;
                return false;
            }
        }



        private void Awake()
        {
            instance ??= this;
        }

        private void Start()
        {
            foreach (var service in adRewardedServices)
                service.Load(() => onAvailable?.Invoke());
        }


        public static void Show(Action<ShowCallback> callback)
        {
            if (adShowing) return;

            if (instance.skipAds)
            {
                callback?.Invoke(ShowCallback.Success);
                return;
            }


            foreach (var service in instance.adRewardedServices)
            {
                if (service.available)
                {
                    adShowing = true;
                    service.Show(() =>
                    {
                        adShowing = false;
                        callback?.Invoke(ShowCallback.Success);
                        service.Load(() => onAvailable?.Invoke());
                    });
                    return;
                }
            }

            callback?.Invoke(ShowCallback.NotAvailable);

            foreach (var service in instance.adRewardedServices)
                service.Load(() => onAvailable?.Invoke());
        }


    }
}
