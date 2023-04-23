using System;
using YandexMobileAds;
using YandexMobileAds.Base;

namespace AdService
{
    public class AdRewarded_YandexMobile : AdRewardedService
    {
        private readonly string logName = "<color=#FFB800>Ads Yandex Mobile</color>";


        private readonly string releaseAdUnitId = "";
        private readonly string testAdUnitId = "demo-rewarded-yandex";

        private RewardedAd _rewardedAd;
        private Action _onRewarded;


        private string adId
        {
            get
            {
                if (RewardedAds.useTestAds) return testAdUnitId;
                else return releaseAdUnitId;
            }
        }


        public override bool available => _rewardedAd != null && _rewardedAd.IsLoaded();

        public override void Load(Action onAvailable)
        {
            _rewardedAd?.Destroy();
            AdRequest adRequest = new AdRequest.Builder().Build();
            _rewardedAd = new RewardedAd(adId);
            _rewardedAd.OnRewardedAdLoaded += (o, e) =>
            {
                onAvailable?.Invoke();
                RewardedAds.Log(logName + ": Ad loaded.");
            };
            _rewardedAd.OnRewardedAdFailedToLoad += OnRewardedAdFailedToLoad;

            _rewardedAd.LoadAd(adRequest);
            RewardedAds.Log(logName + ": Ad requested.");
        }

        private void OnRewardedAdFailedToLoad(object sender, AdFailureEventArgs e)
        {
            _rewardedAd.OnRewardedAdFailedToLoad -= OnRewardedAdFailedToLoad;
            RewardedAds.Log(logName + ": Ad request failed.");
        }

        public override void Show(Action onRewarded)
        {
            _onRewarded = onRewarded;
            _rewardedAd.OnRewarded += OnRewarded;
            _rewardedAd.Show();
        }

        private void OnRewarded(object sender, Reward e)
        {
            RewardedAds.Log(logName + ": On rewarded.");
            _rewardedAd.OnRewarded -= OnRewarded;
            _onRewarded?.Invoke();
        }

    }
}


