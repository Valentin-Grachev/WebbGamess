using UnityEngine;

namespace Cards
{
    public class Button_ToChest : ButtonAction
    {
        [SerializeField] private GameObject _collectionSector;
        [SerializeField] private GameObject _openingSector;
        

        protected override void OnClick()
        {
            _collectionSector.SetActive(false);
            _openingSector.SetActive(true);
            
        }
    }
}



