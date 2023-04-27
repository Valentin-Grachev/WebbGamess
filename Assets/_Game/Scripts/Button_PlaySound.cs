using UnityEngine;

public class Button_PlaySound : ButtonInteract
{
    [SerializeField] private GameObject _frame;
    [SerializeField] private string _audioName;

    private bool _playing = false;

    private void Awake()
    {
        Sounds.onEndSound += () => { _frame.SetActive(false); _playing = false; };
    }



    protected override void OnClick()
    {
        if (!_playing)
        {
            Sounds.Play(_audioName);
            _frame.SetActive(true);
            _playing = true;
        }
        else
        {
            Sounds.Stop();
            _frame.SetActive(false);
            _playing = false;
        }
        
    }




}
