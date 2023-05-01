using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public enum CardSide { Left, Right }

public class Quiz : MonoBehaviour
{
    public static Quiz instance { get; private set; }

    [SerializeField] private AudioYB _audio;
    [SerializeField] private PairsData _pairsData;
    [Space(10)]
    [SerializeField] private Card _leftCard;
    [SerializeField] private Card _rightCard;
    [Space(10)]
    [SerializeField] private SliderPercentage _slider;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _nextLevelText;
    [SerializeField] private GameObject _adLabel;

    [Header("Animations:")]
    [SerializeField] private Anim_Scale _othersAnswerTextAnim;
    [SerializeField] private Anim_Scale _sliderAnim;
    [SerializeField] private Anim_Move _smileAnim;
    [SerializeField] private Anim_Scale _matchedAnim;
    [SerializeField] private Anim_Scale _nextLevelAnim;
    [SerializeField] private Button_NextLevel _nextLevelButton;

    private PairsData.Pair _currentPair;
    private int _level;
    private const int adEveryLevel = 6;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("level")) _level = PlayerPrefs.GetInt("level");
        else
        {
            _level = 1;
            PlayerPrefs.SetInt("level", _level);
        }

        StartGame();
    }


    private void StartGame()
    {
        LoadCardData();
        _leftCard.UpdateImage();
        _rightCard.UpdateImage();
        _leftCard.Deactive();
        _rightCard.Deactive();
        _levelText.text = "Óðîâåíü " + _level.ToString();
    }


    public void ShowAnswer(CardSide selectedCard)
    {
        CardSide winSide = CardSide.Left;

        if (_currentPair.leftPercentage < 50) winSide = CardSide.Right;


        bool win = winSide == selectedCard;

        _leftCard.Active(isTrueAnswer: winSide == CardSide.Left, selectedCard == CardSide.Left);
        _rightCard.Active(isTrueAnswer: winSide == CardSide.Right, selectedCard == CardSide.Right);

        _slider.SetValue(_currentPair.leftPercentage);
        _sliderAnim.Open();
        _smileAnim.Close();


        if (win)
        {
            _matchedAnim.Open();
            _audio.Play("win");
        }
        else _audio.Play("lose");

        _nextLevelAnim.Open();
        _othersAnswerTextAnim.Open();


        _level++;
        PlayerPrefs.SetInt("level", _level);
        PairsData.SavePair(_currentPair);
        _nextLevelButton.active = true;

        if (_level % adEveryLevel == 0)
        {
            _nextLevelText.text = "ÇÀÃÐÓÇÈÒÜ ÑËÅÄÓÞÙÈÅ";
            _adLabel.SetActive(true);
        }
        else
        {
            _nextLevelText.text = "ÑËÅÄÓÞÙÈÉ ÓÐÎÂÅÍÜ";
            _adLabel.SetActive(false);
        }

    }


    public void NextLevel()
    {
        if (_level % adEveryLevel == 0) YandexGame.RewVideoShow(id: 0);

        LoadCardData();
        _levelText.text = "Óðîâåíü " + _level.ToString();

        _leftCard.ChangeCard();
        _rightCard.ChangeCard();
        _leftCard.Deactive();
        _rightCard.Deactive();

        _matchedAnim.Close();
        _nextLevelAnim.Close();
        _othersAnswerTextAnim.Close();
        _sliderAnim.Close();
        _smileAnim.Open();
        

    }



    private void LoadCardData()
    {
        _currentPair = _pairsData.NewPair();
        _leftCard.data = _currentPair.leftCard;
        _rightCard.data = _currentPair.rightCard;
    }


}
