using UnityEngine;


namespace Cards
{
    public class Button_PutCardToCollection : ButtonAction
    {
        [SerializeField] private ChestCard _card;
        [SerializeField] private Anim_PutCardToCollection _anim;

        private void OnEnable()
        {
            _button.interactable = true;
        }


        protected override void OnClick()
        {
            _anim.Animate();
            if (!PlayerPrefs.HasKey(_card.currentCard.name))
            {
                PlayerPrefs.SetInt(_card.currentCard.name, 1);
                NewInCollectionMark.SetNew(true);
            }
                

            _button.interactable = false;
        }
    }
}


