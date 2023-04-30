using DG.Tweening;
using UnityEngine;


public enum CardSide { Left, Right }

public class Quiz : MonoBehaviour
{
    public static Quiz instance { get; private set; }


    [SerializeField] private PairsData _pairsData;
    [Space(10)]
    [SerializeField] private Card _leftCard;
    [SerializeField] private Card _rightCard;
    [Space(10)]
    [SerializeField] private SliderPercentage _slider;

    [Header("Animations:")]
    [SerializeField] private Anim_Scale _othersAnswerTextAnim;
    [SerializeField] private Anim_Scale _sliderAnim;
    [SerializeField] private Anim_Move _smileAnim;
    [SerializeField] private Anim_Move _matchedAnim;
    [SerializeField] private Anim_Move _nextLevelAnim;
    [SerializeField] private Anim_Move _leftCardAnim;
    [SerializeField] private Anim_Move _rightCardAnim;


    private void Awake()
    {
        instance = this;
    }


    public void ShowAnswer(CardSide selectedCard)
    {
        string leftCardName = _leftCard.data.cardName;
        string rightCardName = _rightCard.data.cardName;
        int leftPercentage = 0;
        CardSide winSide = CardSide.Left;

        foreach (var pair in _pairsData.pairs)
        {
            if (pair.leftCard.cardName == leftCardName && pair.rightCard.cardName == rightCardName)
            {
                leftPercentage = pair.leftPercentage;
                if (leftPercentage < 50) winSide = CardSide.Right;
                break;
            }
        }

        bool win = winSide == selectedCard;

        _leftCard.Active(shining: selectedCard == CardSide.Left, correct: winSide == CardSide.Left);
        _rightCard.Active(shining: selectedCard == CardSide.Right, correct: winSide == CardSide.Right);

        _slider.SetValue(leftPercentage);
        _smileAnim.Close();

        if (win) _matchedAnim.Open();

        _nextLevelAnim.Open();

        string key = leftCardName + "_" + rightCardName;
        PlayerPrefs.SetInt(key, 1);
    }


    public void NextLevel()
    {
        DOTween.Sequence().Append(_leftCard.gameObject.SetActive(false));
    }




}
