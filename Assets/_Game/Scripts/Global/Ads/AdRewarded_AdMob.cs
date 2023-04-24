using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AdService
{
    public class AdRewarded_AdMob : AdRewardedService
    {
        [SerializeField] private string _adUnitId;


        private readonly string logName = "<color=#FFFF00>Ads AdMob:</color>";

        private readonly string testAdUnitId = "ca-app-pub-3940256099942544/5224354917";

        private RewardedAd _rewardedAd;
        private Action _onRewarded;
        private bool _initialized;


        private string adId
        {
            get
            {
                if (RewardedAds.useTestAds) return testAdUnitId;
                else return _adUnitId;
            }
        }


        public override bool available
        {
            get
            {
                bool avail = _rewardedAd != null && _rewardedAd.CanShowAd();
                if (!avail) RewardedAds.Log(logName + ": Not available");
                return avail;
            }
        }


        private void Initialize()
        {
            MobileAds.Initialize(initStatus => { });
            _initialized = true;
        }

        public override void Load(Action onAvailable)
        {
            if (!_initialized) Initialize();

            _rewardedAd?.Destroy();
            AdRequest adRequest = new AdRequest.Builder().Build();
            RewardedAd.Load(adId, adRequest, (rewardedAd, error) =>
            {
                _rewardedAd = rewardedAd;
                onAvailable?.Invoke();
                RewardedAds.Log(logName + ": Request completed.");
                if (error != null) RewardedAds.Log(logName + ": Error message: " + error.GetMessage());
            });
            RewardedAds.Log(logName + ": Ad requested.");
        }


        public override void Show(Action onRewarded)
        {
            _onRewarded = onRewarded;
            _rewardedAd.Show((reward) =>
            {
                RewardedAds.Log(logName + ": On rewarded.");
                _onRewarded?.Invoke();
            });
        }
    }

}



