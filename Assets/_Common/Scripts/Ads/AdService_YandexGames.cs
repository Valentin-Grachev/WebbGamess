using System;
using YG;

namespace AdServices
{
    public class AdService_YandexGames : AdService
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




