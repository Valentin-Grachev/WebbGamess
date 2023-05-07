using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    public class Button_OpenCollections : ButtonAction
    {
        [SerializeField] private GameObject _collectionSector;
        [SerializeField] private GameObject _openingSector;
        [SerializeField] private Scrollbar _collectionScrollbar;

        protected override void OnClick()
        {
            _collectionSector.SetActive(true);
            _openingSector.SetActive(false);
            _collectionScrollbar.value = 1;
            NewInCollectionMark.SetNew(false);
        }
    }
}



