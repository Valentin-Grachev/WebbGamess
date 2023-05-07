using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonAction : MonoBehaviour
{
    [SerializeField] protected Button _button;


    protected virtual void Start()
    {
        _button.onClick.AddListener(OnClick);
    }


    protected abstract void OnClick();

}
