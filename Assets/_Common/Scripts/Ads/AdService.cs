using System;
using UnityEngine;


namespace AdServices
{
    public abstract class AdService : MonoBehaviour
    {

        public abstract bool available { get; }

        public abstract void Show(Action onRewarded);

        public abstract void Load(Action onAvailable);

    }
}
