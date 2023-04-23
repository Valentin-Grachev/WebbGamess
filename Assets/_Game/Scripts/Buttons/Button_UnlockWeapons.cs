using UnityEngine;
using YG;

public class Button_UnlockWeapons : ButtonInteract
{
    [SerializeField] private GameObject _cells;
    [SerializeField] private GameObject _block;


    protected override void OnClick()
    {

        RewardedAds.Show((callback) =>
        {
            if (callback == RewardedAds.CallbackType.Success)
            {
                _cells.SetActive(true);
                _block.SetActive(false);
            }
        });        
    }
}
