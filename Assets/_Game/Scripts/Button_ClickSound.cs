using UnityEngine;

public class Button_ClickSound : ButtonClick
{
    [SerializeField] private AudioYB _audio;
    [SerializeField] private string _soundName;

    protected override void OnClick()
    {
        _audio.Play(_soundName);
    }
}
