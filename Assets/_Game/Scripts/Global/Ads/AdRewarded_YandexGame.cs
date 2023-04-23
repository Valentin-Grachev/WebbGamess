using System;
using YG;

public class AdRewarded_YandexGame : AdRewardedService
{

    private Action _onRewarded;

    public override bool available => true;

    public override void Load(Action onAvailable)
    {
        onAvailable?.Invoke();
    }

    public override void Show(Action onRewarded)
    {
        _onRewarded = onRewarded;
        YandexGame.RewardVideoEvent += OnRewarded;
        YandexGame.RewVideoShow(id: 0);
    }


    private void OnRewarded(int id)
    {
        _onRewarded?.Invoke();
        YandexGame.RewardVideoEvent -= OnRewarded;
    }


}

