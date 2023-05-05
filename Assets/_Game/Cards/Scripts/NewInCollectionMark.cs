using UnityEngine;

namespace Cards
{
    public class NewInCollectionMark : MonoBehaviour
    {
        [SerializeField] private GameObject _label;

        private static GameObject label;


        private void Awake()
        {
            label = _label;
            if (PlayerPrefs.HasKey("new"))
            {
                int value = PlayerPrefs.GetInt("new");
                if (value == 0) _label.SetActive(false);
                else _label.SetActive(true);
            }
        }

        public static void SetNew(bool active)
        {
            label.SetActive(active);
            if (active) PlayerPrefs.SetInt("new", 1);
            else PlayerPrefs.SetInt("new", 0);

        }




    }
}



