using System;
using UnityEngine;

public abstract class AdRewardedService : MonoBehaviour
{

    public abstract bool available { get; }

    public abstract void Show(Action onRewarded);

    public abstract void Load(Action onAvailable);

}
