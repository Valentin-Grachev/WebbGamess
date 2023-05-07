using UnityEngine;
using AdServices;

namespace Cards
{
    public class Button_OpenChest : ButtonAction
    {
        [SerializeField] private Anim_OpenChest _anim;
        [SerializeField] private GameObject _adOn;
        [SerializeField] private GameObject _adOff;


        protected override void OnClick()
        {
            int chestsLeft = 2;
            if (PlayerPrefs.HasKey("chests")) 
                chestsLeft = PlayerPrefs.GetInt("chests");

            if (chestsLeft > 0)
            {
                _anim.OpenChest();
                chestsLeft--;
                PlayerPrefs.SetInt("chests", chestsLeft);
            }
            
            else
            {
                Ads.Show((callback) =>
                {
                    if (callback == Ads.ShowCallback.Success)
                    {
                        chestsLeft = 1;
                        _anim.OpenChest();
                        PlayerPrefs.SetInt("chests", chestsLeft);
                    }
                });
            }

        }

        private void OnEnable()
        {
            int chestsLeft = 2;
            if (PlayerPrefs.HasKey("chests"))
                chestsLeft = PlayerPrefs.GetInt("chests");

            if (chestsLeft > 0)
            {
                _adOff.SetActive(true);
                _adOn.SetActive(false);
            }
            else
            {
                _adOff.SetActive(false);
                _adOn.SetActive(true);
            }
        }




    }
}

