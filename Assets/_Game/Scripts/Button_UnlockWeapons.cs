using UnityEngine;
using YG;

public class Button_UnlockWeapons : ButtonInteract
{
    [SerializeField] private GameObject _cells;
    [SerializeField] private GameObject _block;


    protected override void OnClick()
    {
        YandexGame.RewardVideoEvent += (id) => 
        { 
            _cells.SetActive(true);
            _block.SetActive(false);
        };
        YandexGame.RewVideoShow(id: 0);
        
    }
}
