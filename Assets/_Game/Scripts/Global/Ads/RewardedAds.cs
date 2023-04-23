using System;
using System.Collections.Generic;
using UnityEngine;

public class RewardedAds : MonoBehaviour
{
    public enum CallbackType { Success, NotAvailable }

    private static RewardedAds instance;
    public static Action onAvailable;


    [SerializeField] private List<AdRewardedService> adRewardedServices;

    [Space(10)]
    [SerializeField] private bool showLogs;
    [SerializeField] private bool _useTestAds; public bool useTestAds { get => instance._useTestAds; }
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


    public static void Show(Action<CallbackType> callback)
    {
        if (instance.skipAds) callback?.Invoke(CallbackType.Success);


        foreach (var service in instance.adRewardedServices)
        {
            if (service.available)
            {
                service.Show(() => callback?.Invoke(CallbackType.Success));
            }
        }

        callback?.Invoke(CallbackType.NotAvailable);

        foreach (var service in instance.adRewardedServices)
            service.Load(() => onAvailable?.Invoke());
    }


}
