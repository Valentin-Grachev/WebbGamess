using UnityEngine;

public class Button_NextLevel : ButtonClick
{
    [SerializeField] private AudioYB _audio;

    public bool active = true;

    protected override void OnClick()
    {
        if (!active) return;

        Quiz.instance.NextLevel();
        _audio.Play("click");
    }
}
