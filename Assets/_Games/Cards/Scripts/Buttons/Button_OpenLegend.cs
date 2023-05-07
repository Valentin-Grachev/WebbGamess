using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdServices;

namespace Cards
{
    public class Button_OpenLegend : ButtonAction
    {
        [SerializeField] private LegendCard _legendCard;

        protected override void OnClick()
        {
            Ads.Show((callvack) =>
            {
                if (callvack == Ads.ShowCallback.Success)
                {
                    PlayerPrefs.SetInt("Legend", 2);
                    _legendCard.UpdateCard();
                }
            });
        }
    }
}

