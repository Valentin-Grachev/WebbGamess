using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Quiz
{
    public class SliderPercentage : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _leftText;
        [SerializeField] private TextMeshProUGUI _rightText;



        public void SetValue(int leftPercentage)
        {
            _leftText.text = leftPercentage.ToString() + "%";
            _rightText.text = (100 - leftPercentage).ToString() + "%";

            _slider.value = leftPercentage / 100f;
        }



    }
}

