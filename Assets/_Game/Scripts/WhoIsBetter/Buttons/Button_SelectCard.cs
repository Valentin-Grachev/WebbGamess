using UnityEngine;

public class Button_SelectCard : ButtonClick
{
    [SerializeField] private CardSide _cardSide;
    [SerializeField] private AudioYB _audio;

    protected override void OnClick()
    {
        Quiz.instance.ShowAnswer(_cardSide);
        _audio.Play("click");
    }
}
