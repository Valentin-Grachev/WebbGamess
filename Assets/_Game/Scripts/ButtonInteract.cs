using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonInteract : MonoBehaviour
{
    [SerializeField] private Button _button;


    private void Start()
    {
        _button.onClick.AddListener(OnClick);
    }


    protected abstract void OnClick();

}
