using UnityEngine;

public class Button_DeleteSaves : ButtonAction
{

    private int click = 8;

    protected override void OnClick()
    {
        click--;
        if (click == 0)
        {
            PlayerPrefs.DeleteAll();
            _button.image.color = Color.green;
        }

    }
}
