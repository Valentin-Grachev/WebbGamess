using UnityEngine;

namespace Cards
{
    public class Button_TurnCard : ButtonClick
    {
        [SerializeField] private Anim_TurnCard _anim;

        protected override void OnClick()
        {
            _button.interactable = false;
            CardParty.SetInteraction(false);
            _anim.Open();
        }
    }
}



