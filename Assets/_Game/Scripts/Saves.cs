using UnityEngine;

public class Saves : MonoBehaviour
{
    [SerializeField] private string _key;
    [SerializeField] private int _value;


    [ContextMenu("Set Key")]
    private void SetKey()
    {
        PlayerPrefs.SetInt(_key, _value);
    }



    [ContextMenu("Delete all")]
    private void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
