using System;
using YG;

namespace AdService
{
    public class RewardedAd_YandexGames : AdRewardedService
    {
        public override bool available => true;

        public override void Load(Action onAvailable) { }

        public override void Show(Action onRewarded)
        {
            YandexGame.RewardVideoEvent += (arg) => onRewarded?.Invoke();
            YandexGame.RewVideoShow(0);
        }





    }
}




