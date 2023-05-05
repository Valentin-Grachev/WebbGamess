using UnityEngine;
using YG;

public class Button_UnlockWeapons : ButtonClick
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
        YandexGame.RewardVideoEvent += (id) => 
        { 
            _cells.SetActive(true);
            _block.SetActive(false);
            PlayerPrefs.SetInt(_blockKey, 1);
        };
        YandexGame.RewVideoShow(id: 0);
        
    }
}
