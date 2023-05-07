using AdServices;
using UnityEngine;

namespace Sounds
{
    public class Button_UnlockPack : ButtonAction
    {
        [SerializeField] private string _blockKey;
        [SerializeField] private GameObject _cells;
        [SerializeField] private GameObject _block;

        protected override void Start()
        {
            base.Start();
            if (_blockKey == string.Empty) return;

            if (PlayerPrefs.HasKey(_blockKey))
            {
                _cells.SetActive(true);
                _block.SetActive(false);
            }
        }


        protected override void OnClick()
        {
            Ads.Show((callback) =>
            {
                if (callback == Ads.ShowCallback.Success)
                {
                    _cells.SetActive(true);
                    _block.SetActive(false);
                    PlayerPrefs.SetInt(_blockKey, 1);
                }
            });
        }
    }
}



